using UnityEngine;
using UnityEngine.InputSystem;
using VoidChase.Spaceship.Input;
using VoidChase.Spaceship.Projectiles;

namespace VoidChase.Spaceship
{
	public class ShootingController : MonoBehaviour
	{
		[field: SerializeField]
		private ProjectilesPool CurrentProjectilesPool { get; set; }

		protected virtual void Start ()
		{
			AttachToEvents();
		}

		protected virtual void OnDestroy ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			SpaceshipInputProvider.Instance.ShootInputAction.performed += OnShoot;
		}

		private void DetachFromEvents ()
		{
			SpaceshipInputProvider.Instance.ShootInputAction.performed += OnShoot;
		}

		private void OnShoot (InputAction.CallbackContext obj)
		{
			ProjectileController projectile = CurrentProjectilesPool.Get();

			AttachToProjectileEvents(projectile);
			projectile.Launch(transform.position, transform.forward);
		}

		private void AttachToProjectileEvents (ProjectileController projectile)
		{
			projectile.Hit += OnHit;
			projectile.ReachLifeTime += OnReachLifeTime;
		}

		private void DetachFromProjectileEvents (ProjectileController projectile)
		{
			projectile.Hit -= OnHit;
			projectile.ReachLifeTime -= OnReachLifeTime;
		}

		private void OnHit (ProjectileController projectile)
		{
			DetachFromProjectileEvents(projectile);
			CurrentProjectilesPool.Release(projectile);
		}

		private void OnReachLifeTime (ProjectileController projectile)
		{
			DetachFromProjectileEvents(projectile);
			CurrentProjectilesPool.Release(projectile);
		}
	}
}