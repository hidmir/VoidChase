using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Modules;

namespace VoidChase.Spaceship
{
	public class SpaceshipController : MonoBehaviour
	{
		[field: SerializeField]
		private SpaceshipMovementController MovementController { get; set; }
		[field: SerializeField]
		private ShootingController ShootingController { get; set; }
		[field: SerializeField]
		private ModulesCollectionController ModulesCollectionController { get; set; }

		public void KillPlayer ()
		{
			//TODO: Refactor?
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
			MovementController.SetMovementState(!isPaused);
			ShootingController.isShootingEnabled = !isPaused;
		}
	}
}