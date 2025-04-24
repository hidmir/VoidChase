using UnityEngine;
using VoidChase.Modules;
using VoidChase.PauseManagement;

namespace VoidChase.Spaceship
{
	public class SpaceshipController : MonoBehaviour, IPausable
	{
		[field: SerializeField]
		private SpaceshipMovementController MovementController { get; set; }
		[field: SerializeField]
		private ShootingController ShootingController { get; set; }
		[field: SerializeField]
		private ModulesCollectionController ModulesCollectionController { get; set; }

		public void OnPause ()
		{
			SetSpaceshipPauseState(true);
		}

		public void OnResume ()
		{
			SetSpaceshipPauseState(false);
		}

		private void Start ()
		{
			Initialize();
		}

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void Reset ()
		{
			MovementController = GetComponent<SpaceshipMovementController>();
			ShootingController = GetComponent<ShootingController>();
			ModulesCollectionController = GetComponent<ModulesCollectionController>();
		}

		private void Initialize ()
		{
			ModulesCollectionController.InitializeModules();
			MovementController.SetMovementState(true);
			ShootingController.isShootingEnabled = true;
		}

		private void SetSpaceshipPauseState (bool isPaused)
		{
			MovementController.SetMovementState(!isPaused);
			ShootingController.isShootingEnabled = !isPaused;
		}
	}
}