using UnityEngine.InputSystem;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Input
{
	public class SpaceshipInputProvider : SingletonMonoBehaviour<SpaceshipInputProvider>
	{
		public InputAction MovementInputAction => CurrentSpaceshipInput.Controlls.Movement;
		public InputAction ShootingInputAction => CurrentSpaceshipInput.Controlls.Shoot;

		private SpaceshipInput CurrentSpaceshipInput { get; set; }

		protected override void Initialize ()
		{
			base.Initialize();
			InitializeInput();
		}

		protected override void Shutdown ()
		{
			base.Shutdown();
			CurrentSpaceshipInput.Disable();
		}

		private void InitializeInput ()
		{
			CurrentSpaceshipInput = new SpaceshipInput();
			CurrentSpaceshipInput.Enable();
		}
	}
}