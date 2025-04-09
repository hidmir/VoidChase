using System;
using UnityEngine;
using UnityEngine.Events;
using VoidChase.PauseManagement;
using VoidChase.Utilities;

namespace VoidChase.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour, IPausable
	{
		public event Action FiringReady = delegate { };

		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent ShotFired { get; set; }

		[field: Header("Firing Settings")]
		[field: SerializeField]
		public bool UsesFireRate { get; private set; }
		[field: SerializeField]
		private float FireRate { get; set; }

		private float FireCooldown { get; set; }
		private bool isPaused;

		public virtual void Initialize ()
		{
			FireCooldown = 0.0f;
			FiringReady.Invoke();
		}

		public void Fire (Vector2 position)
		{
			if (!IsReadyToFire())
			{
				return;
			}

			OnFire(position);
			ShotFired.Invoke();
			FireCooldown = 1.0f / FireRate;
		}

		public void OnPause ()
		{
			isPaused = true;
		}

		public void OnResume ()
		{
			isPaused = false;
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

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void UpdateFireCooldown ()
		{
			if (UsesFireRate && !isPaused && FireCooldown > 0.0f)
			{
				FireCooldown -= Time.deltaTime;

				if (FireCooldown <= 0.0f)
				{
					FiringReady.Invoke();
				}
			}
		}
	}
}