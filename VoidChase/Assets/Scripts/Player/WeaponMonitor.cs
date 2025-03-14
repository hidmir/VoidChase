using System;
using UnityEngine;
using VoidChase.Spaceship;

namespace VoidChase.Player
{
	public class WeaponMonitor : MonoBehaviour
	{
		public static event Action<string> PlayerWeaponUpdated = delegate { };

		[field: SerializeField]
		private ShootingController BoundShootingController { get; set; }

		private string InitialWeapon => BoundShootingController.InitialWeapon;
		private string CurrentWeapon => BoundShootingController.CurrentWeaponName;

		private void Start ()
		{
			BoundShootingController.WeaponChanged.AddListener(OnWeaponChanged);
			PlayerWeaponUpdated.Invoke(InitialWeapon);
		}

		private void OnDestroy ()
		{
			BoundShootingController.WeaponChanged.RemoveListener(OnWeaponChanged);
		}

		private void OnWeaponChanged (string _)
		{
			PlayerWeaponUpdated.Invoke(CurrentWeapon);
		}
	}
}