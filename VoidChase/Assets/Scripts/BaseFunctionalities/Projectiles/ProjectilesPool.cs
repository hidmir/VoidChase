using UnityEngine;
using UnityEngine.Pool;

namespace VoidChase.BaseFunctionalities.Projectiles
{
	public class ProjectilesPool : MonoBehaviour
	{
		[field: SerializeField]
		private int PoolSize { get; set; } = 50;
		[field: SerializeField]
		private int PoolMaxSize { get; set; } = 150;
		[field: SerializeField]
		private ProjectileController Prefab { get; set; }

		protected ObjectPool<ProjectileController> CurrentPool { get; private set; }

		public ProjectileController Get ()
		{
			return CurrentPool.Get();
		}

		public void Release (ProjectileController movingObject)
		{
			CurrentPool.Release(movingObject);
		}

		protected virtual void Awake ()
		{
			Initialize();
		}

		protected virtual void Initialize ()
		{
			CurrentPool = new ObjectPool<ProjectileController>(CreateObject, GetObject, ReleaseObject, null, true, PoolSize, PoolMaxSize);
		}

		private ProjectileController CreateObject ()
		{
			ProjectileController projectile = Instantiate(Prefab, transform);
			projectile.gameObject.SetActive(false);

			return projectile;
		}

		private void GetObject (ProjectileController projectile)
		{
			projectile.Initialize();
		}

		private void ReleaseObject (ProjectileController projectile)
		{
			projectile.DeInitialize();
		}
	}
}