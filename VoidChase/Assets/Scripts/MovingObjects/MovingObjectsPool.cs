using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using VoidChase.Utilities;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace VoidChase.MovingObjects
{
	[Serializable]
	public class MovingObjectsPool
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private int PoolSize { get; set; } = 50;
		[field: SerializeField]
		private int PoolMaxSize { get; set; } = 150;
		[field: SerializeField]
		private List<MovingObjectController> PrefabCollection { get; set; }

		protected ObjectPool<MovingObjectController> CurrentPool { get; private set; }
		private Transform cachedParent;

		public void Initialize (Transform objectsParent)
		{
			cachedParent = objectsParent;
			CurrentPool = new ObjectPool<MovingObjectController>(CreateObject, GetObject, ReleaseObject, null, true, PoolSize, PoolMaxSize);
		}

		public MovingObjectController Get ()
		{
			return CurrentPool.Get();
		}

		public void Release (MovingObjectController movingObject)
		{
			CurrentPool.Release(movingObject);
		}

		private MovingObjectController CreateObject ()
		{
			MovingObjectController movingObject = Object.Instantiate(GetRandomPrefab(), cachedParent);
			movingObject.gameObject.SetActive(false);

			return movingObject;
		}

		private void GetObject (MovingObjectController movingObject)
		{
			movingObject.Initialize();
			movingObject.gameObject.SetActive(true);
		}

		private void ReleaseObject (MovingObjectController movingObject)
		{
			movingObject.gameObject.SetActive(false);
			movingObject.DeInitialize();
		}

		private MovingObjectController GetRandomPrefab ()
		{
			int spawnerIndex = Random.Range(0, PrefabCollection.Count);
			return PrefabCollection[spawnerIndex];
		}
	}
}