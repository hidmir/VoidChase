using UnityEngine;
using UnityEngine.Events;

namespace VoidChase.Modules
{
	public class DestructibleModule : BaseModule, IDamageable
	{
		[field: SerializeField]
		public UnityEvent Die { get; set; }

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
				Die.Invoke();
			}
		}
	}
}