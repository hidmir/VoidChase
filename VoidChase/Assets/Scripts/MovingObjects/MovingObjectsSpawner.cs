using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsSpawner : BaseMovingObjectsSpawner
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField, Dropdown(StringCollectionNames.MOVING_OBJECTS_COLLECTION_NAME)]
		private string MovingObjectName { get; set; }

		protected MovingObjectsPool CurrentPool
		{
			get
			{
				if (cachedPool == null)
				{
					cachedPool = GetPoolByName();
				}
				
				return cachedPool;
			}
		}

		private MovingObjectsPool cachedPool;

		public override void Spawn (Vector3 position, Vector3 direction)
		{
			MovingObjectController movingObject = CurrentPool.Get();
			AttachToEvents(movingObject);
			movingObject.Launch(position, direction);
		}

		protected virtual void AttachToEvents (MovingObjectController movingObject)
		{
			movingObject.RequestDestroying += OnRequestDestroying;
		}

		protected virtual void DetachFromEvents (MovingObjectController movingObject)
		{
			movingObject.RequestDestroying -= OnRequestDestroying;
		}

		private void OnRequestDestroying (MovingObjectController movingObject)
		{
			DeSpawn(movingObject);
		}

		private void DeSpawn (MovingObjectController movingObject)
		{
			DetachFromEvents(movingObject);
			CurrentPool.Release(movingObject);
		}

		private MovingObjectsPool GetPoolByName ()
		{
			MovingObjectsPoolProvider.Instance.TryGetObject(MovingObjectName, out MovingObjectsPool pool);
			return pool;
		}
	}
}