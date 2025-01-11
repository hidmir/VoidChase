using System;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	[Serializable]
	public class MovingObjectData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.MOVING_OBJECTS_COLLECTION_NAME)]
		public string Name { get; set; }
		[field: SerializeField]
		public MovingObjectsPool ObjectReference { get; private set; }
	}
}