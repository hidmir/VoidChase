using UnityEngine;
using VoidChase.Environment.GameSpeed;
using VoidChase.GameLoop.Pause;
using VoidChase.Utilities;

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
		private float SpawningFrequency { get; set; } = 1.0f;
		[field: SerializeField]
		private Vector3 SpawningDirection { get; set; } = Vector3.down;
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

		private float timeSinceLastSpawning;
		private bool isSpawningEnabled = true;

		public void OnPause ()
		{
			isSpawningEnabled = false;
		}

		public void OnResume ()
		{
			isSpawningEnabled = true;
		}

		protected virtual void Update ()
		{
			if (isSpawningEnabled)
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
			((IPausable)this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void SpawnMovingObjects ()
		{
			timeSinceLastSpawning += Time.deltaTime;

			if (CanSpawnMovingObject())
			{
				Vector3 position = GetRandomPosition();
				Spawner.Spawn(position, SpawningDirection);

				timeSinceLastSpawning = 0.0f;
			}
		}

		private bool CanSpawnMovingObject ()
		{
			float frequency = IsAffectedByGameSpeed ? SpawningFrequency * GameSpeedSO.CurrentSpeed : SpawningFrequency;
			return timeSinceLastSpawning > 1.0f / frequency;
		}

		private Vector3 GetRandomPosition ()
		{
			float positionValue = GetRandomPositionOnSpawningAxisValue();
			Vector3 position = GetPositionOnSpawningAxis(positionValue);

			return position;
		}

		private float GetRandomPositionOnSpawningAxisValue ()
		{
			(float minPositionValue, float maxPositionValue) = GetSpawnPositionMinMaxValue();
			return Random.Range(minPositionValue, maxPositionValue);
		}

		private (float minPositionValue, float maxPositionValue) GetSpawnPositionMinMaxValue ()
		{
			Vector3 currentPosition = transform.position;
			float halfSpawningAreaSize = SpawningAreaSize / 2.0f;

#pragma warning disable CS8524
			float currentPositionOnSpawningAxisValue = SpawningRangeAxis switch
			{
				Axis.X => currentPosition.x,
				Axis.Y => currentPosition.y,
				Axis.Z => currentPosition.z
			};
#pragma warning restore CS8524

			float minPositionValue = currentPositionOnSpawningAxisValue - halfSpawningAreaSize;
			float maxPositionValue = currentPositionOnSpawningAxisValue + halfSpawningAreaSize;

			return (minPositionValue, maxPositionValue);
		}

		private Vector3 GetPositionOnSpawningAxis (float positionOnSpawningAxisValue)
		{
			Vector3 currentPosition = transform.position;

#pragma warning disable CS8524
			return SpawningRangeAxis switch
			{
				Axis.X => new Vector3(positionOnSpawningAxisValue, currentPosition.y, currentPosition.z),
				Axis.Y => new Vector3(currentPosition.x, positionOnSpawningAxisValue, currentPosition.z),
				Axis.Z => new Vector3(currentPosition.x, currentPosition.y, positionOnSpawningAxisValue)
			};
#pragma warning restore CS8524
		}

		private void DrawSpawningRange ()
		{
			(Vector3 minPosition, Vector3 maxPosition) = GetSpawnMinMaxPosition();

			Gizmos.color = VisualizationColor;
			GizmosExtensions.DrawWireCapsule(minPosition, maxPosition, VisualizationWidth);
		}

		private (Vector3 minPosition, Vector3 maxPosition) GetSpawnMinMaxPosition ()
		{
			(float minPositionValue, float maxPositionValue) = GetSpawnPositionMinMaxValue();
			return (GetPositionOnSpawningAxis(minPositionValue), GetPositionOnSpawningAxis(maxPositionValue));
		}

		private enum Axis
		{
			X,
			Y,
			Z
		}
	}
}