using UnityEngine;
using UnityEngine.Events;
using VoidChase.Utilities;

namespace VoidChase.Modules
{
	public class DamageSourceModule : BaseModule
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent DamageableHit { get; private set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private int Damage { get; set; } = 1;

		private void OnTriggerEnter2D (Collider2D other)
		{
			AttemptInflictDamage(other);
		}

		private void AttemptInflictDamage (Collider2D objectHit)
		{
			if (objectHit.TryGetComponent(out IDamageable damageableObject))
			{
				damageableObject.InflictDamage(Damage);
				DamageableHit.Invoke();
			}
		}
	}
}