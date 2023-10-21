using System;
using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Utilities;
using Random = UnityEngine.Random;

namespace VoidChase.MovingObjects
{
	public class AreaMovingObjectsSpawner : MovingObjectsSpawner
	{
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

		private float TimeSinceLastSpawning { get; set; }

		private const string INCORRECT_SPAWNING_RANGE_AXIS_VALUE = "SpawningRangeAxis value is incorrect ({0}).";

		protected virtual void Update ()
		{
			SpawnMovingObjects();
		}

		protected virtual void OnDrawGizmos ()
		{
			DrawSpawningRange();
		}

		private void SpawnMovingObjects ()
		{
			TimeSinceLastSpawning += Time.deltaTime;

			if (CanSpawnMovingObject())
			{
				Vector3 position = GetRandomPosition();
				Spawn(position, SpawningDirection);

				TimeSinceLastSpawning = 0.0f;
			}
		}

		private bool CanSpawnMovingObject ()
		{
			float frequency = IsAffectedByGameSpeed ? SpawningFrequency * GetCurrentGameSpeed() : SpawningFrequency;
			return TimeSinceLastSpawning > 1.0f / frequency;
		}

		private float GetCurrentGameSpeed ()
		{
			return GameManager.Instance.CurrentGameSpeedController.CurrentSpeed;
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

			float currentPositionOnSpawningAxisValue = SpawningRangeAxis switch
			{
				Axis.X => currentPosition.x,
				Axis.Y => currentPosition.y,
				Axis.Z => currentPosition.z,
				_ => throw new ArgumentException(String.Format(INCORRECT_SPAWNING_RANGE_AXIS_VALUE, SpawningRangeAxis))
			};

			float minPositionValue = currentPositionOnSpawningAxisValue - (SpawningAreaSize / 2.0f);
			float maxPositionValue = currentPositionOnSpawningAxisValue + (SpawningAreaSize / 2.0f);

			return (minPositionValue, maxPositionValue);
		}

		private Vector3 GetPositionOnSpawningAxis (float positionOnSpawningAxisValue)
		{
			Vector3 currentPosition = transform.position;

			return SpawningRangeAxis switch
			{
				Axis.X => new Vector3(positionOnSpawningAxisValue, currentPosition.y, currentPosition.z),
				Axis.Y => new Vector3(currentPosition.x, positionOnSpawningAxisValue, currentPosition.z),
				Axis.Z => new Vector3(currentPosition.x, currentPosition.y, positionOnSpawningAxisValue),
				_ => throw new ArgumentException(String.Format(INCORRECT_SPAWNING_RANGE_AXIS_VALUE, SpawningRangeAxis))
			};
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