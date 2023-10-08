using UnityEngine.InputSystem;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Input
{
	public class SpaceshipInputProvider : SingletonMonoBehaviour<SpaceshipInputProvider>
	{
		public InputAction MovementInputAction => CurrentSpaceshipInput.Controlls.Movement;
		public InputAction ShootInputAction => CurrentSpaceshipInput.Controlls.Shoot;
		
		private SpaceshipInput CurrentSpaceshipInput { get; set; }

		protected override void Initialize ()
		{
			base.Initialize();
			InitializeInput();
		}

		private void InitializeInput ()
		{
			CurrentSpaceshipInput = new SpaceshipInput();
			CurrentSpaceshipInput.Enable();
		}
	}
}