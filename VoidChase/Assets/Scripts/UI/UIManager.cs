using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI
{
	public class UIManager : SingletonMonoBehaviour<UIManager>
	{
		[field: SerializeField]
		private PanelsProvider CurrentPanelsProvider { get; set; }

		public void ShowPanel (PanelType panelType)
		{
			SetPanelState(panelType, true);
		}

		public void HidePanel (PanelType panelType)
		{
			SetPanelState(panelType, false);
		}

		protected virtual void Start ()
		{
			SetAllPanelsState(false);
		}

		private void SetAllPanelsState (bool isEnabled)
		{
			foreach (GameObject panel in CurrentPanelsProvider.GetAllObjects())
			{
				panel.SetActive(isEnabled);
			}
		}

		private void SetPanelState (PanelType panelType, bool isEnabled)
		{
			if (CurrentPanelsProvider.TryGetObject(panelType, out GameObject objectReference))
			{
				objectReference.SetActive(isEnabled);
			}
		}
	}
}