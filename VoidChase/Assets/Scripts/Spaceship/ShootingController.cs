using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using VoidChase.Spaceship.Input;
using VoidChase.Utilities;
using VoidChase.Utilities.Dropdown;
using VoidChase.Weapons;

namespace VoidChase.Spaceship
{
	public class ShootingController : MonoBehaviour
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent<string> WeaponChanged { get; set; }

		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		public WeaponsProvider BoundWeaponsProvider { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField, Dropdown(StringCollectionNames.WEAPONS_COLLECTION_NAME)]
		public string InitialWeapon { get; private set; }

		public string CurrentWeaponName { get; private set; }

		private BaseWeapon currentWeapon;

		[NonSerialized]
		public bool isShootingEnabled;

		public void SelectWeapon (string weaponName)
		{
			if (BoundWeaponsProvider.TryGetWeapon(weaponName, out BaseWeapon weapon))
			{
				CurrentWeaponName = weaponName;
				currentWeapon = weapon;
				currentWeapon.Initialize();

				WeaponChanged.Invoke(weaponName);
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

			currentWeapon.Fire(transform.position);
		}
	}
}