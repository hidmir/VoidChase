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
		[field: SerializeField, Dropdown(StringCollectionNames.WEAPONS_COLLECTION_NAME)]
		private string InitialWeapon { get; set; }

		public bool IsShootingEnabled { get; set; }
		private BaseWeapon CurrentWeapon { get; set; }

		public void SelectWeapon (string weaponName)
		{
			WeaponsProvider.Instance.TryGetObject(weaponName, out BaseWeapon weapon);
			CurrentWeapon = weapon;
		}

		protected virtual void Start ()
		{
			SelectWeapon(InitialWeapon);
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
			if (!IsShootingEnabled)
			{
				return;
			}

			CurrentWeapon.Shoot(transform.position);
		}
	}
}