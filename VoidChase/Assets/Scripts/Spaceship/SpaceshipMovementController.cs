using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Spaceship.Input;
using VoidChase.Utilities;

namespace VoidChase.Spaceship
{
	public class SpaceshipMovementController : MonoBehaviour
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private Rigidbody CurrentRigidbody { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float MovementSpeed { get; set; } = 5.0f;
		[field: SerializeField]
		private float BrakingSpeed { get; set; } = 5.0f;

		protected virtual void Update ()
		{
			UpdateMovement();
		}

		private void UpdateMovement ()
		{
			Vector2 movementInputValue = SpaceshipInputProvider.Instance.MovementInputAction.ReadValue<Vector2>();
			Vector2 velocity = movementInputValue != Vector2.zero ? GetMovementVelocity(movementInputValue) : GetBrakingVelocity();

			CurrentRigidbody.velocity = ClampVelocityToSceneBoundaries(velocity);
		}

		private Vector2 GetMovementVelocity (Vector2 movementInputValue)
		{
			return movementInputValue * MovementSpeed;
		}

		private Vector2 GetBrakingVelocity ()
		{
			return Vector2.Lerp(CurrentRigidbody.velocity, Vector2.zero, BrakingSpeed * Time.deltaTime);
		}

		private Vector2 ClampVelocityToSceneBoundaries (Vector2 velocity)
		{
			(float maxX, float minX, float maxY, float minY) = GameManager.Instance.CurrentSceneBoundariesController.GetMaxMinPositions();
			Vector3 currentPosition = CurrentRigidbody.transform.position;

			bool isMaxXReached = currentPosition.x >= maxX;
			bool isMinXReached = currentPosition.x <= minX;
			bool isMaxYReached = currentPosition.y >= maxY;
			bool isMinYReached = currentPosition.y <= minY;

			float clampedVelocityOnX = (isMaxXReached && velocity.x > 0) || (isMinXReached && velocity.x < 0) ? 0.0f : velocity.x;
			float clampedVelocityOnY = (isMaxYReached && velocity.y > 0) || (isMinYReached && velocity.y < 0) ? 0.0f : velocity.y;

			return new Vector2(clampedVelocityOnX, clampedVelocityOnY);
		}
	}
}