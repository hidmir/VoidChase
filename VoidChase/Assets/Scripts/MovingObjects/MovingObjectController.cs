using System;
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
		private MovingObjectMovementBehaviour CurrentMovementBehaviour { get; set; }
		[field: SerializeField]
		private ModulesCollectionController CurrentModulesCollectionController { get; set; }

		public void Initialize ()
		{
			CurrentMovementBehaviour.Initialize();
			CurrentModulesCollectionController.InitializeModules();
		}

		public void DeInitialize ()
		{
			CurrentMovementBehaviour.DeInitialize();
		}

		public void Launch (Vector3 position, Vector3 direction)
		{
			CurrentMovementBehaviour.Launch(position, direction);
		}

		public void RequestDestroying ()
		{
			DestroyingRequested.Invoke(this);
		}

		public void OnPause ()
		{
			CurrentMovementBehaviour.isMovementEnabled = false;
		}

		public void OnResume ()
		{
			CurrentMovementBehaviour.isMovementEnabled = true;
		}

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}
	}
}