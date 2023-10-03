using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VoidChase.Spaceship.Projectiles
{
	public class ProjectilesSpawner : MonoBehaviour
	{
		[field: SerializeField]
		private ProjectilesPool CurrentProjectilesPool { get; set; }
		[field: SerializeField]
		private float SpawningFrequency { get; set; }
		[field: SerializeField]
		private Vector3 SpawningDirection { get; set; }
		[field: SerializeField]
		private float SpawningAreaSize { get; set; }
		[field: SerializeField]
		private Axis SpawningRangeAxis { get; set; }

		private float TimeSinceLastSpawning { get; set; }

		protected virtual void Update ()
		{
			SpawnProjectiles();
		}

		protected virtual void OnDrawGizmos ()
		{
			DrawSpawningRange();
		}

		private void SpawnProjectiles ()
		{
			TimeSinceLastSpawning += Time.deltaTime;

			if (CanSpawnProjectile())
			{
				Vector3 position = GetRandomProjectilePosition();
				ProjectileController projectile = CurrentProjectilesPool.Get();
				projectile.Launch(position, SpawningDirection);

				TimeSinceLastSpawning = 0.0f;
			}
		}

		private bool CanSpawnProjectile ()
		{
			return TimeSinceLastSpawning > 1.0f / SpawningFrequency;
		}

		private Vector3 GetRandomProjectilePosition ()
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
			float minPositionValue = currentPosition.x - (SpawningAreaSize / 2.0f);
			float maxPositionValue = currentPosition.x + (SpawningAreaSize / 2.0f);

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
				_ => throw new ArgumentException($"SpawningRangeAxis value is incorrect ({SpawningRangeAxis}).")
			};
		}

		private void DrawSpawningRange ()
		{
			(Vector3 minPosition, Vector3 maxPosition) = GetSpawnMinMaxPosition();

			Gizmos.color = Color.yellow;
			GizmosExtensions.DrawWireCapsule(minPosition, maxPosition, 0.5f);
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