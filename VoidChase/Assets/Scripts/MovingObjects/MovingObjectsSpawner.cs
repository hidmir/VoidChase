using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsSpawner : BaseMovingObjectsSpawner
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private MovingObjectsPool Pool { get; set; }

		public override void Spawn (Vector2 position, Vector2 direction)
		{
			MovingObjectController movingObject = Pool.Get();
			AttachToEvents(movingObject);
			movingObject.Launch(position, direction);
		}

		private void Awake ()
		{
			Pool.Initialize(transform);
		}

		private void AttachToEvents (MovingObjectController movingObject)
		{
			movingObject.DestroyingRequested += OnDestroyingRequested;
		}

		private void DetachFromEvents (MovingObjectController movingObject)
		{
			movingObject.DestroyingRequested -= OnDestroyingRequested;
		}

		private void OnDestroyingRequested (MovingObjectController movingObject)
		{
			DeSpawn(movingObject);
		}

		private void DeSpawn (MovingObjectController movingObject)
		{
			DetachFromEvents(movingObject);
			Pool.Release(movingObject);
		}
	}
}