using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.MovingObjects
{
	public class MovingObjectsPoolProvider :  SingletonMonoBehaviour<MovingObjectsPoolProvider>
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private List<MovingObjectData> ObjectDataCollection { get; set; }

		public bool TryGetObject (string name, out MovingObjectsPool movingObjectsPool)
		{
			movingObjectsPool = ObjectDataCollection.FirstOrDefault(weaponData => weaponData.Name == name)?.ObjectReference;

			if (movingObjectsPool == null)
			{
				Debug.LogError($"Cannot find moving object with name {name}.");
			}

			return movingObjectsPool != null;
		}
	}
}