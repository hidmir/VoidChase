using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Modules;

namespace VoidChase.Spaceship
{
	public class SpaceshipController : MonoBehaviour
	{
		[SerializeField] private SpaceshipMovementController spaceshipMovementController;
		[SerializeField] private ShootingController shootingController;
		[SerializeField] private ModulesCollectionController modulesCollectionController;

		public void KillPlayer ()
		{
			GameManager.Instance.EndGame();
		}

		private void Start ()
		{
			Initialize();
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void Reset ()
		{
			spaceshipMovementController = GetComponent<SpaceshipMovementController>();
			shootingController = GetComponent<ShootingController>();
			modulesCollectionController = GetComponent<ModulesCollectionController>();
		}

		private void Initialize ()
		{
			modulesCollectionController.InitializeModules();
			spaceshipMovementController.SetMovementState(true);
			shootingController.IsShootingEnabled = true;
		}

		private void AttachToEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged += OnIsGamePausedValueChanged;
		}

		private void DetachFromEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged -= OnIsGamePausedValueChanged;
		}

		private void OnIsGamePausedValueChanged (bool isPaused)
		{
			spaceshipMovementController.SetMovementState(!isPaused);
			shootingController.IsShootingEnabled = !isPaused;
		}
	}
}