using UnityEngine.InputSystem;

namespace VoidChase.Spaceship.Input
{
	public class SpaceshipInputProvider : SingletonMonoBehaviour<SpaceshipInputProvider>
	{
		public InputAction MovementInputAction => CurrentSpaceshipInput.Controlls.Movement;
		
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