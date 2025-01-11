using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI
{
	public class UIManager : SingletonMonoBehaviour<UIManager>
	{
		[field: SerializeField]
		private PanelsProvider CurrentPanelsProvider { get; set; }

		public void ShowPanel (string panelName)
		{
			SetPanelState(panelName, true);
		}

		public void HidePanel (string panelName)
		{
			SetPanelState(panelName, false);
		}

		protected virtual void Start ()
		{
			SetAllPanelsState(false);
		}

		private void SetAllPanelsState (bool isEnabled)
		{
			foreach (PanelController panel in CurrentPanelsProvider.GetAllPanels())
			{
				panel.SetVisibility(isEnabled);
			}
		}

		private void SetPanelState (string panelName, bool isEnabled)
		{
			if (CurrentPanelsProvider.TryGetPanel(panelName, out PanelController objectReference))
			{
				objectReference.SetVisibility(isEnabled);
			}
		}
	}
}