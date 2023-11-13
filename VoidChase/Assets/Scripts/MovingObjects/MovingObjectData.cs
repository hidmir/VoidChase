using System;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	[Serializable]
	public class MovingObjectData : ObjectData<string, MovingObjectsPool>
	{
		[field: SerializeField, Dropdown(StringCollectionNames.MOVING_OBJECTS_COLLECTION_NAME)]
		public override string Key { get; set; }
	}
}