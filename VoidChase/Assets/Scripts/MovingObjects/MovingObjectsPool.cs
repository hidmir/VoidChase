using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsPool : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private int PoolSize { get; set; } = 50;
		[field: SerializeField]
		private int PoolMaxSize { get; set; } = 150;
		[field: SerializeField]
		private List<MovingObjectController> PrefabCollection { get; set; }

		protected ObjectPool<MovingObjectController> CurrentPool { get; private set; }

		public MovingObjectController Get ()
		{
			return CurrentPool.Get();
		}

		public void Release (MovingObjectController movingObject)
		{
			CurrentPool.Release(movingObject);
		}

		protected virtual void Awake ()
		{
			Initialize();
		}

		protected virtual void Initialize ()
		{
			CurrentPool = new ObjectPool<MovingObjectController>(CreateObject, GetObject, ReleaseObject, null, true, PoolSize, PoolMaxSize);
		}

		private MovingObjectController CreateObject ()
		{
			MovingObjectController movingObject = Instantiate(GetRandomPrefab(), transform);
			movingObject.gameObject.SetActive(false);

			return movingObject;
		}

		private void GetObject (MovingObjectController movingObject)
		{
			movingObject.Initialize();
		}

		private void ReleaseObject (MovingObjectController movingObject)
		{
			movingObject.DeInitialize();
		}

		private MovingObjectController GetRandomPrefab ()
		{
			int spawnerIndex = Random.Range(0, PrefabCollection.Count);
			return PrefabCollection[spawnerIndex];
		}
	}
}