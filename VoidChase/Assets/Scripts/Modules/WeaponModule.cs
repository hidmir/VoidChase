using UnityEngine;
using VoidChase.Utilities;
using VoidChase.Weapons;

namespace VoidChase.Modules
{
	public class WeaponModule : BaseModule
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private BaseWeapon BoundWeapon { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private bool IsFiringAutomatically { get; set; }

		private const string IncorrectWeaponShootingModeMessage = "The module will be inactive because the weapon has {0} mode disabled. Automatic firing every frame is disabled for optimisation purposes.";

		public void Fire ()
		{
			BoundWeapon.Fire(transform.position);
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			if (IsFiringAutomatically)
			{
				if (BoundWeapon.UsesFireRate)
				{
					BoundWeapon.FiringReady += OnFiringReady;
				}
				else
				{
					Debug.LogError(string.Format(IncorrectWeaponShootingModeMessage, nameof(BoundWeapon.UsesFireRate)), this);
				}
			}
		}

		private void DetachFromEvents ()
		{
			if (IsFiringAutomatically)
			{
				if (BoundWeapon.UsesFireRate)
				{
					BoundWeapon.FiringReady -= OnFiringReady;
				}
			}
		}

		private void OnFiringReady ()
		{
			Fire();
		}
	}
}