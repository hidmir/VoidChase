using UnityEngine;
using UnityEngine.InputSystem;
using VoidChase.Spaceship.Input;
using VoidChase.Spaceship.Weapons;
using VoidChase.Utilities;

namespace VoidChase.Spaceship
{
	public class ShootingController : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private string InitialWeapon { get; set; }

		private BaseWeapon CurrentWeapon { get; set; }

		protected virtual void Start ()
		{
			CacheInitialWeapon();
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
			if (SpaceshipInputProvider.Instance != null)
			{
				SpaceshipInputProvider.Instance.ShootInputAction.performed -= OnShoot;
			}
		}

		private void OnShoot (InputAction.CallbackContext obj)
		{
			CurrentWeapon.Shoot(transform.position);
		}

		private void CacheInitialWeapon ()
		{
			WeaponsProvider.Instance.TryGetObject(InitialWeapon, out BaseWeapon weapon);
			CurrentWeapon = weapon;
		}
	}
}