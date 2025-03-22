using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VoidChase.MovingObjects
{
	public class RandomMovingObjectsSpawner : BaseMovingObjectsSpawner
	{
		[field: SerializeField]
		private List<SpawnerData> SpawnersCollection { get; set; }

		public override void Initialize ()
		{
			foreach (SpawnerData spawnerData in SpawnersCollection)
			{
				spawnerData.Spawner.Initialize();
			}
		}

		public override void Spawn (Vector2 position, Vector2 direction)
		{
			MovingObjectsSpawner spawner = GetRandomSpawner();
			spawner.Spawn(position, direction);
		}

		private MovingObjectsSpawner GetRandomSpawner ()
		{
			float totalProbability = SpawnersCollection.Sum(spawnerData => spawnerData.Probability);

			float randomValue = Random.Range(0.0f, totalProbability);
			float currentSum = 0.0f;
			int spawnerIndex = 0;

			for (; spawnerIndex < SpawnersCollection.Count; spawnerIndex++)
			{
				SpawnerData spawnerData = SpawnersCollection[spawnerIndex];
				currentSum += spawnerData.Probability;

				if (currentSum > randomValue)
				{
					break;
				}
			}

			return SpawnersCollection[spawnerIndex].Spawner;
		}

		[Serializable]
		private class SpawnerData
		{
			[field: SerializeField]
			public MovingObjectsSpawner Spawner { get; private set; }
			[field: SerializeField, Range(0.0f, 1.0f)]
			public float Probability { get; private set; } = 1.0f;
		}
	}
}