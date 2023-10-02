using UnityEngine;
using UnityEngine.Pool;

namespace VoidChase.Spaceship.Projectiles
{
	public class ProjectilesPool : MonoBehaviour
	{
		[field: SerializeField]
		private int PoolSize { get; set; } = 50;
		[field: SerializeField]
		private int PoolMaxSize { get; set; } = 150;
		[field: SerializeField]
		private ProjectileController ProjectilePrefab { get; set; }

		protected ObjectPool<ProjectileController> CurrentPool { get; private set; }

		public ProjectileController Get ()
		{
			return CurrentPool.Get();
		}

		public void Release (ProjectileController projectileController)
		{
			CurrentPool.Release(projectileController);
		}

		protected virtual void Awake ()
		{
			Initialize();
		}

		private void Initialize ()
		{
			CurrentPool = new ObjectPool<ProjectileController>(CreateProjectile, GetProjectile, ReleaseProjectile, null, true, PoolSize, PoolMaxSize);
		}

		private ProjectileController CreateProjectile ()
		{
			ProjectileController projectile = Instantiate(ProjectilePrefab, transform);
			projectile.gameObject.SetActive(false);

			return projectile;
		}

		private void GetProjectile (ProjectileController projectile)
		{
			projectile.Initialize();
		}

		private void ReleaseProjectile (ProjectileController projectile)
		{
			projectile.DeInitialize();
		}
	}
}