using UnityEngine;
using VoidChase.Spaceship.Input;

namespace VoidChase.Spaceship
{
	public class SpaceshipMovementController : MonoBehaviour
	{
		[field: SerializeField]
		private float MovementSpeed { get; set; } = 5.0f;
		[field: SerializeField]
		private float BrakingSpeed { get; set; } = 5.0f;
		[field: SerializeField]
		private Rigidbody CurrentRigidbody { get; set; }

		protected virtual void Update ()
		{
			UpdateMovement();
		}

		private void UpdateMovement ()
		{
			Vector2 movementInputValue = SpaceshipInputProvider.Instance.MovementInputAction.ReadValue<Vector2>();
			Vector2 velocity = movementInputValue != Vector2.zero ? GetMovementVelocity(movementInputValue) : GetBrakingVelocity();

			CurrentRigidbody.velocity = velocity;
		}

		private Vector2 GetMovementVelocity (Vector2 movementInputValue)
		{
			return movementInputValue * MovementSpeed;
		}

		private Vector2 GetBrakingVelocity ()
		{
			return Vector2.Lerp(CurrentRigidbody.velocity, Vector2.zero, BrakingSpeed * Time.deltaTime);
		}
	}
}