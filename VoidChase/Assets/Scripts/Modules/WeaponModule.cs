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

		private bool isFiringEnabled;

		private const string IncorrectWeaponShootingModeMessage = "The module will be inactive because the weapon has {0} mode disabled. Automatic firing every frame is disabled for optimisation purposes.";

		public void Fire ()
		{
			BoundWeapon.Fire(transform.position);
		}

		public override void Initialize ()
		{
			base.Initialize();
			BoundWeapon.Initialize();
		}

		public override void DeInitialize ()
		{
			base.DeInitialize();
			SetFiringState(false);
		}

		public void SetFiringState (bool isEnabled)
		{
			isFiringEnabled = isEnabled;

			if (isEnabled)
			{
				AttachToEvents();
				Fire();
			}
			else
			{
				DetachFromEvents();
			}
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
					Debug.LogWarning(string.Format(IncorrectWeaponShootingModeMessage, nameof(BoundWeapon.UsesFireRate)), this);
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