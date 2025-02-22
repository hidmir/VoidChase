using System;
using UnityEngine;
using UnityEngine.Events;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectMovementBehaviour : MonoBehaviour
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent LifeTimeReached { get; private set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float Speed { get; set; } = 5.0f;
		[field: SerializeField]
		private float LifeTime { get; set; } = 5.0f;

		[NonSerialized]
		public bool isMovementEnabled;
		private Vector3 cachedDirection;
		private bool isLaunched;
		private float timeSinceLaunching;

		public virtual void Initialize ()
		{
			isMovementEnabled = true;
		}

		public virtual void Launch (Vector3 position, Vector3 direction)
		{
			transform.position = position;
			cachedDirection = direction;
			isLaunched = true;
		}

		public virtual void DeInitialize ()
		{
			isLaunched = false;
			timeSinceLaunching = 0.0f;
		}

		protected virtual void Update ()
		{
			if (isLaunched && isMovementEnabled)
			{
				UpdatePosition();
				UpdateTimeSinceLaunching();
			}
		}

		private void UpdatePosition ()
		{
			Vector3 currentPosition = transform.position;
			Vector3 newPosition = currentPosition + cachedDirection * (Speed * Time.deltaTime);

			transform.position = newPosition;
		}

		private void UpdateTimeSinceLaunching ()
		{
			timeSinceLaunching += Time.deltaTime;

			if (timeSinceLaunching > LifeTime)
			{
				LifeTimeReached.Invoke();
			}
		}
	}
}