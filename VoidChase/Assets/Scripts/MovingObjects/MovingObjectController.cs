using System;
using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Modules;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectController : MonoBehaviour
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

		public void InvokeRequestDestroying ()
		{
			DestroyingRequested.Invoke(this);
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged += OnIsGamePausedValueChanged;
		}

		private void DetachFromEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged -= OnIsGamePausedValueChanged;
		}

		private void OnIsGamePausedValueChanged (bool isGamePaused)
		{
			CurrentMovementBehaviour.IsMovementEnabled = !isGamePaused;
		}
	}
}