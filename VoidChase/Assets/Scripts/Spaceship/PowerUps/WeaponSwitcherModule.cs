using UnityEngine;
using UnityEngine.Events;
using VoidChase.Modules;
using VoidChase.Spaceship.Weapons;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.PowerUps
{
	public class WeaponSwitcherModule : BaseModule
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent SwitchWeapon { get; private set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private WeaponType WeaponType { get; set; }

		protected virtual void OnTriggerEnter (Collider other)
		{
			AttemptSwitchWeapon(other);
		}

		private void AttemptSwitchWeapon (Collider objectHit)
		{
			if (objectHit.TryGetComponent(out ShootingController shootingController))
			{
				shootingController.SelectWeapon(WeaponType);
				SwitchWeapon.Invoke();
			}
		}
	}
}