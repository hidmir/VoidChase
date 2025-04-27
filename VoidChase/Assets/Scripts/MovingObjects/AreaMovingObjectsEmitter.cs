using UnityEngine;
using VoidChase.Audio;
using VoidChase.Environment.GameSpeed;
using VoidChase.PauseManagement;
using VoidChase.Utilities;
using VoidChase.Utilities.Attributes;

namespace VoidChase.MovingObjects
{
	public class AreaMovingObjectsEmitter : MonoBehaviour, IPausable
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private BaseMovingObjectsSpawner Spawner { get; set; }
		[field: SerializeField]
		private GameSpeedSO GameSpeedSO { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private EmitterStartTrigger StartTrigger { get; set; }
		[field: SerializeField, ShowIf(nameof(IsStartTriggerAudio)), Min(0)]
		private int StartAudioEventNumber { get; set; }
		[field: SerializeField]
		private EmitterEndTrigger EndTrigger { get; set; }
		[field: SerializeField, ShowIf(nameof(IsEndTriggerAudio)), Min(0)]
		private int EndAudioEventNumber { get; set; }

		[field: Space]
		[field: SerializeField]
		private float SpawningFrequency { get; set; } = 1.0f;
		[field: SerializeField]
		private Vector2 SpawningDirection { get; set; } = Vector2.down;
		[field: SerializeField]
		private float SpawningAreaSize { get; set; } = 5.0f;
		[field: SerializeField]
		private Axis SpawningRangeAxis { get; set; } = Axis.X;
		[field: SerializeField]
		private bool IsAffectedByGameSpeed { get; set; } = true;

		[field: Header(InspectorNames.VISUALIZATION_NAME)]
		[field: SerializeField]
		private Color VisualizationColor { get; set; } = Color.yellow;
		[field: SerializeField]
		private float VisualizationWidth { get; set; } = 0.5f;

		private bool IsStartTriggerAudio => StartTrigger is EmitterStartTrigger.AudioEvent;
		private bool IsEndTriggerAudio => EndTrigger is EmitterEndTrigger.AudioEvent;

		private float timeSinceLastSpawning;
		private bool isSpawningEnabled;
		private bool isPaused;

		public void OnPause ()
		{
			isPaused = true;
		}

		public void OnResume ()
		{
			isPaused = false;
		}

		protected virtual void Update ()
		{
			if (isSpawningEnabled && !isPaused)
			{
				SpawnMovingObjects();
			}
		}

		protected virtual void OnDrawGizmos ()
		{
			DrawSpawningRange();
		}

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void Start ()
		{
			if (StartTrigger is EmitterStartTrigger.StartUnityFunction)
			{
				isSpawningEnabled = true;
			}

			Spawner.Initialize();
			AttachToEvents();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void OnDestroy ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			AudioEventsController.AudioEventInvoked += OnAudioEventInvoked;
		}

		private void DetachFromEvents ()
		{
			AudioEventsController.AudioEventInvoked -= OnAudioEventInvoked;
		}

		private void OnAudioEventInvoked (int eventIndex)
		{
			if (IsStartTriggerAudio && StartAudioEventNumber == eventIndex)
			{
				isSpawningEnabled = true;
			}

			if (IsEndTriggerAudio && EndAudioEventNumber == eventIndex)
			{
				isSpawningEnabled = false;
			}
		}

		private void SpawnMovingObjects ()
		{
			timeSinceLastSpawning += Time.deltaTime;

			if (CanSpawnMovingObject())
			{
				Vector2 position = GetRandomPosition();
				Spawner.Spawn(position, SpawningDirection);

				timeSinceLastSpawning = 0.0f;
			}
		}

		private bool CanSpawnMovingObject ()
		{
			float frequency = IsAffectedByGameSpeed ? SpawningFrequency * GameSpeedSO.CurrentSpeed : SpawningFrequency;
			return timeSinceLastSpawning > 1.0f / frequency;
		}

		private Vector2 GetRandomPosition ()
		{
			float positionValue = GetRandomPositionOnSpawningAxisValue();
			Vector2 position = GetPositionOnSpawningAxis(positionValue);

			return position;
		}

		private float GetRandomPositionOnSpawningAxisValue ()
		{
			(float minPositionValue, float maxPositionValue) = GetSpawnPositionMinMaxValue();
			return Random.Range(minPositionValue, maxPositionValue);
		}

		private (float minPositionValue, float maxPositionValue) GetSpawnPositionMinMaxValue ()
		{
			Vector2 currentPosition = transform.position;
			float halfSpawningAreaSize = SpawningAreaSize / 2.0f;

#pragma warning disable CS8524
			float currentPositionOnSpawningAxisValue = SpawningRangeAxis switch
			{
				Axis.X => currentPosition.x,
				Axis.Y => currentPosition.y
			};
#pragma warning restore CS8524

			float minPositionValue = currentPositionOnSpawningAxisValue - halfSpawningAreaSize;
			float maxPositionValue = currentPositionOnSpawningAxisValue + halfSpawningAreaSize;

			return (minPositionValue, maxPositionValue);
		}

		private Vector2 GetPositionOnSpawningAxis (float positionOnSpawningAxisValue)
		{
			Vector2 currentPosition = transform.position;

#pragma warning disable CS8524
			return SpawningRangeAxis switch
			{
				Axis.X => new Vector2(positionOnSpawningAxisValue, currentPosition.y),
				Axis.Y => new Vector2(currentPosition.x, positionOnSpawningAxisValue)
			};
#pragma warning restore CS8524
		}

		private void DrawSpawningRange ()
		{
			(Vector2 minPosition, Vector2 maxPosition) = GetSpawnMinMaxPosition();

			Gizmos.color = VisualizationColor;
			GizmosExtensions.DrawWireCapsule(minPosition, maxPosition, VisualizationWidth);
		}

		private (Vector2 minPosition, Vector2 maxPosition) GetSpawnMinMaxPosition ()
		{
			(float minPositionValue, float maxPositionValue) = GetSpawnPositionMinMaxValue();
			return (GetPositionOnSpawningAxis(minPositionValue), GetPositionOnSpawningAxis(maxPositionValue));
		}

		private enum Axis
		{
			X,
			Y
		}
	}
}