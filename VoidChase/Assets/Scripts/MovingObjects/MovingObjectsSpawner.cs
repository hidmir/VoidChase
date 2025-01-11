using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsSpawner : BaseMovingObjectsSpawner
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private MovingObjectsPool Pool { get; set; }

		public override void Spawn (Vector3 position, Vector3 direction)
		{
			if (Pool == null)
			{
				return;
			}
			
			MovingObjectController movingObject = Pool.Get();
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
			Pool.Release(movingObject);
		}
	}
}