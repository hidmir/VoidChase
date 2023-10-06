using UnityEngine;

namespace VoidChase.Projectiles
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
			projectile.RequestDestroying += OnRequestDestroying;
		}

		protected virtual void DetachFromProjectileEvents (ProjectileController projectile)
		{
			projectile.RequestDestroying -= OnRequestDestroying;
		}

		private void OnRequestDestroying (ProjectileController projectile)
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