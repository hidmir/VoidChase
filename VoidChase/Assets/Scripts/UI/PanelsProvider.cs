using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI
{
	public class PanelsProvider : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private List<PanelData> PanelDataCollection { get; set; }

		public bool TryGetPanel (string panelName, out BasePanelController panel)
		{
			panel = PanelDataCollection.FirstOrDefault(panelData => panelData.Name == panelName)?.ObjectReference;

			if (panel == null)
			{
				Debug.LogError($"Cannot find panel with name {panelName}.");
			}

			return panel != null;
		}

		public IEnumerable<BasePanelController> GetAllPanels ()
		{
			return PanelDataCollection.Select(panelData => panelData.ObjectReference);
		}
	}
}