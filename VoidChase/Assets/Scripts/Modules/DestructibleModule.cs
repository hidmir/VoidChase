using UnityEngine;
using UnityEngine.Events;
using VoidChase.Utilities;

namespace VoidChase.Modules
{
	public class DestructibleModule : BaseModule, IDamageable
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent ObjectDestroyed { get; set; }
		[field: SerializeField]
		public UnityEvent<int> DamageTaken { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		public int InitialHealth { get; private set; } = 1;

		public int Health { get; private set; }

		public override void Initialize ()
		{
			base.Initialize();
			Health = InitialHealth;
		}

		public void InflictDamage (int damage)
		{
			if (damage <= 0)
			{
				return;
			}

			Health -= damage;
			DamageTaken.Invoke(damage);

			if (Health <= 0.0f)
			{
				ObjectDestroyed.Invoke();
			}
		}
	}
}