using System;
using System.Collections;
using UnityEngine;
using VoidChase.GameLoop.Pause;
using VoidChase.Modules;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectController : MonoBehaviour, IPausable
	{
		public event Action<MovingObjectController> DestroyingRequested = delegate { };

		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private Renderer MainObjectRenderer { get; set; }
		[field: SerializeField]
		private Collider2D MainObjectCollider { get; set; }
		[field: SerializeField]
		private MovingObjectMovementBehaviour CurrentMovementBehaviour { get; set; }
		[field: SerializeField]
		private ModulesCollectionController CurrentModulesCollectionController { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private bool HasDestructionEffect { get; set; }
		[field: SerializeField]
		private ParticleSystem DestructionEffect { get; set; }

		private bool isPaused;

		public void Initialize ()
		{
			SetMainObjectState(true);
			CurrentMovementBehaviour.Initialize();
			CurrentModulesCollectionController.InitializeModules();
		}

		public void DeInitialize ()
		{
			CurrentMovementBehaviour.DeInitialize();
		}

		public void Launch (Vector2 position, Vector2 direction)
		{
			CurrentMovementBehaviour.Launch(position, direction);
		}

		public void RequestDestroying ()
		{
			if (HasDestructionEffect && gameObject.activeInHierarchy)
			{
				StartCoroutine(DestroyingProcess());
			}
			else
			{
				InvokeDestroyingRequested();
			}
		}

		public void OnPause ()
		{
			if (HasDestructionEffect)
			{
				DestructionEffect.Pause();
			}

			CurrentMovementBehaviour.isMovementEnabled = false;
			isPaused = true;
		}

		public void OnResume ()
		{
			if (HasDestructionEffect && DestructionEffect.isPaused)
			{
				DestructionEffect.Play();
			}

			CurrentMovementBehaviour.isMovementEnabled = true;
			isPaused = false;
		}

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private IEnumerator DestroyingProcess ()
		{
			SetMainObjectState(false);
			CurrentMovementBehaviour.DeInitialize();

			ParticleSystem.MainModule mainModule = DestructionEffect.main;
			float effectDuration = mainModule.duration;
			float maxLifetime = mainModule.startLifetime.constantMax;

			float processDuration = effectDuration + maxLifetime;

			DestructionEffect.Play();

			float timeSinceEffectStart = 0.0f;

			while (timeSinceEffectStart < processDuration)
			{
				yield return null;

				if (!isPaused)
				{
					timeSinceEffectStart += Time.deltaTime;
				}
			}

			InvokeDestroyingRequested();
		}

		private void InvokeDestroyingRequested ()
		{
			DestroyingRequested.Invoke(this);
		}

		private void SetMainObjectState (bool isEnabled)
		{
			MainObjectRenderer.enabled = isEnabled;
			MainObjectCollider.enabled = isEnabled;
		}
	}
}