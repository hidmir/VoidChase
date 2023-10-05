using UnityEngine;

namespace VoidChase.BaseFunctionalities.Projectiles
{
	public class ProjectilesSpawner : MonoBehaviour
	{
		[field: SerializeField]
		protected ProjectilesPool CurrentProjectilesPool { get; private set; }

		public void Spawn (Vector3 position, Vector3 direction)
		{
			ProjectileController projectile = CurrentProjectilesPool.Get();
			AttachToProjectileEvents(projectile);
			projectile.Launch(position, direction);
		}

		protected virtual void AttachToProjectileEvents (ProjectileController projectile)
		{
			projectile.ReachLifeTime += OnReachLifeTime;
			projectile.Hit += OnHit;
		}

		protected virtual void DetachFromProjectileEvents (ProjectileController projectile)
		{
			projectile.ReachLifeTime -= OnReachLifeTime;
			projectile.Hit -= OnHit;
		}

		private void OnReachLifeTime (ProjectileController projectile)
		{
			DeSpawnProjectile(projectile);
		}

		private void OnHit (ProjectileController projectile)
		{
			DeSpawnProjectile(projectile);
		}

		private void DeSpawnProjectile (ProjectileController projectile)
		{
			DetachFromProjectileEvents(projectile);
			CurrentProjectilesPool.Release(projectile);
		}
	}
}