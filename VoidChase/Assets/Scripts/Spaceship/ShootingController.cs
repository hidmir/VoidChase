using UnityEngine;
using UnityEngine.InputSystem;
using VoidChase.Projectiles;
using VoidChase.Spaceship.Input;

namespace VoidChase.Spaceship
{
	public class ShootingController : MonoBehaviour
	{
		[field: SerializeField]
		private ProjectilesSpawner CurrentProjectilesSpawner { get; set; }

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
			SpaceshipInputProvider.Instance.ShootInputAction.performed -= OnShoot;
		}

		private void OnShoot (InputAction.CallbackContext obj)
		{
			CurrentProjectilesSpawner.Spawn(transform.position, transform.forward);
		}
	}
}