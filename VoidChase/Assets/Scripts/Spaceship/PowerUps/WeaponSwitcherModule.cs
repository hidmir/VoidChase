using UnityEngine;
using UnityEngine.Events;
using VoidChase.Modules;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.PowerUps
{
	public class WeaponSwitcherModule : BaseModule
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent WeaponSwitched { get; private set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField, Dropdown(StringCollectionNames.WEAPONS_COLLECTION_NAME)]
		private string WeaponName { get; set; }

		protected virtual void OnTriggerEnter (Collider other)
		{
			AttemptSwitchWeapon(other);
		}

		private void AttemptSwitchWeapon (Collider objectHit)
		{
			if (objectHit.TryGetComponent(out ShootingController shootingController))
			{
				shootingController.SelectWeapon(WeaponName);
				WeaponSwitched.Invoke();
			}
		}
	}
}