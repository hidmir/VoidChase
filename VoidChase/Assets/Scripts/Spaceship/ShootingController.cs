using System;
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

		[NonSerialized]
		public bool isShootingEnabled;
		private BaseWeapon currentWeapon;

		public void SelectWeapon (string weaponName)
		{
			if (WeaponsProvider.Instance.TryGetWeapon(weaponName, out BaseWeapon weapon))
			{
				currentWeapon = weapon;
			}
			else
			{
				Debug.LogError($"Cannot find weapon with name: {weaponName}. Weapon won't be changed.");
			}
		}

		private void Start ()
		{
			SelectWeapon(InitialWeapon);
			AttachToEvents();
		}

		private void OnDestroy ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			SpaceshipInputProvider.Instance.ShootingInputAction.performed += OnShoot;
		}

		private void DetachFromEvents ()
		{
			if (SpaceshipInputProvider.Instance != null)
			{
				SpaceshipInputProvider.Instance.ShootingInputAction.performed -= OnShoot;
			}
		}

		private void OnShoot (InputAction.CallbackContext obj)
		{
			if (!isShootingEnabled)
			{
				return;
			}

			currentWeapon.Shoot(transform.position);
		}
	}
}