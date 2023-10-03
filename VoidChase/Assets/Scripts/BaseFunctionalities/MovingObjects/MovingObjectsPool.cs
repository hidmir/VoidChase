using UnityEngine;
using UnityEngine.Pool;

namespace VoidChase.BaseFunctionalities.MovingObjects
{
	public class MovingObjectsPool<TObject> : MonoBehaviour where TObject : MovingObjectController
	{
		[field: SerializeField]
		private int PoolSize { get; set; } = 50;
		[field: SerializeField]
		private int PoolMaxSize { get; set; } = 150;
		[field: SerializeField]
		private TObject Prefab { get; set; }

		protected ObjectPool<TObject> CurrentPool { get; private set; }

		public TObject Get ()
		{
			return CurrentPool.Get();
		}

		public void Release (TObject projectileController)
		{
			CurrentPool.Release(projectileController);
		}

		protected virtual void Awake ()
		{
			Initialize();
		}

		protected virtual void Initialize ()
		{
			CurrentPool = new ObjectPool<TObject>(CreateObject, GetObject, ReleaseObject, null, true, PoolSize, PoolMaxSize);
		}

		private TObject CreateObject ()
		{
			TObject projectile = Instantiate(Prefab, transform);
			projectile.gameObject.SetActive(false);

			return projectile;
		}

		private void GetObject (TObject projectile)
		{
			projectile.Initialize();
		}

		private void ReleaseObject (TObject projectile)
		{
			projectile.DeInitialize();
		}
	}
}