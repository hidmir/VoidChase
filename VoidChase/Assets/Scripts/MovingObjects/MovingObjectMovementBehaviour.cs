using UnityEngine;
using UnityEngine.Events;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectMovementBehaviour : MonoBehaviour
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent ReachLifeTime { get; private set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float Speed { get; set; } = 5.0f;
		[field: SerializeField]
		private float LifeTime { get; set; } = 5.0f;

		public bool IsMovementEnabled { get; set; }
		private Vector3 Direction { get; set; }
		private bool IsLaunched { get; set; }
		private float TimeSinceLaunching { get; set; }

		public virtual void Initialize ()
		{
			gameObject.SetActive(true);
			IsMovementEnabled = true;
		}

		public virtual void Launch (Vector3 position, Vector3 direction)
		{
			transform.position = position;
			Direction = direction;
			IsLaunched = true;
		}

		public virtual void DeInitialize ()
		{
			IsLaunched = false;
			TimeSinceLaunching = 0.0f;
			gameObject.SetActive(false);
		}

		protected virtual void Update ()
		{
			if (IsLaunched && IsMovementEnabled)
			{
				UpdatePosition();
				UpdateTimeSinceLaunching();
			}
		}

		private void UpdatePosition ()
		{
			Vector3 currentPosition = transform.position;
			Vector3 newPosition = currentPosition + Direction * (Speed * Time.deltaTime);

			transform.position = newPosition;
		}

		private void UpdateTimeSinceLaunching ()
		{
			TimeSinceLaunching += Time.deltaTime;

			if (TimeSinceLaunching > LifeTime)
			{
				ReachLifeTime.Invoke();
			}
		}
	}
}