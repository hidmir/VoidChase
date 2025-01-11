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

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float InitialHealth { get; set; } = 1.0f;
		
		private float Health { get; set; }

		public override void Initialize ()
		{
			base.Initialize();
			Health = InitialHealth;
		}
		
		public void InflictDamage (float damage)
		{
			Health -= damage;

			if (Health <= 0.0f)
			{
				ObjectDestroyed.Invoke();
			}
		}
	}
}