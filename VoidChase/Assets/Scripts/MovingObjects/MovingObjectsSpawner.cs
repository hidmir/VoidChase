using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsSpawner : BaseMovingObjectsSpawner
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private MovingObjectsPool BoundPool { get; set; }

		public override void Spawn (Vector3 position, Vector3 direction)
		{
			if (BoundPool == null)
			{
				return;
			}
			
			MovingObjectController movingObject = BoundPool.Get();
			AttachToEvents(movingObject);
			movingObject.Launch(position, direction);
		}

		protected virtual void AttachToEvents (MovingObjectController movingObject)
		{
			movingObject.DestroyingRequested += OnDestroyingRequested;
		}

		protected virtual void DetachFromEvents (MovingObjectController movingObject)
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
			BoundPool.Release(movingObject);
		}
	}
}