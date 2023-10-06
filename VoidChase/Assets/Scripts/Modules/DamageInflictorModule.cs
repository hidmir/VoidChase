using UnityEngine;
using UnityEngine.Events;

namespace VoidChase.Modules
{
	public class DamageInflictorModule : BaseModule
	{
		[field: SerializeField]
		public UnityEvent Hit { get; private set; }

		[field: SerializeField]
		private float Damage { get; set; } = 1.0f;

		protected virtual void OnTriggerEnter (Collider other)
		{
			AttemptInflictDamage(other);
		}

		private void AttemptInflictDamage (Collider objectHit)
		{
			if (objectHit.TryGetComponent(out IDamageable damageableObject))
			{
				damageableObject.InflictDamage(Damage);
				Hit.Invoke();
			}
		}
	}
}