using System;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI
{
	[Serializable]
	public class PanelData : ObjectData<string, PanelController>
	{
		[field: SerializeField, Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)]
		public override string Key { get; set; }
	}
}