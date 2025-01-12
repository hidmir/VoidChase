using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.UI
{
	[Serializable]
	public class PanelData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)]
		public string Name { get; set; }
		[field: SerializeField]
		public PanelController ObjectReference { get; private set; }
	}
}