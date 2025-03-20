using UnityEngine;

namespace VoidChase.Spaceship.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		[field: Header("Firing Settings")]
		[field: SerializeField]
		private bool UsesFireRate { get; set; }
		[field: SerializeField]
		private float FireRate { get; set; }

		private float FireCooldown { get; set; }

		public virtual void Initialize ()
		{
			FireCooldown = 0.0f;
		}

		public void Fire (Vector2 position)
		{
			if (!IsReadyToFire())
			{
				return;
			}

			OnFire(position);
			FireCooldown = 1.0f / FireRate;
		}

		protected abstract void OnFire (Vector2 position);

		protected virtual bool IsReadyToFire ()
		{
			return !UsesFireRate || FireCooldown <= 0.0f;
		}

		protected virtual void Update ()
		{
			UpdateFireCooldown();
		}

		private void UpdateFireCooldown ()
		{
			if (UsesFireRate && FireCooldown > 0.0f)
			{
				FireCooldown -= Time.deltaTime;
			}
		}
	}
}