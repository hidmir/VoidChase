using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.UI
{
	[Serializable]
	public class PanelData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.PanelsCollectionName)]
		public string Name { get; private set; }
		[field: SerializeField]
		public BasePanelController ObjectReference { get; private set; }
	}
}