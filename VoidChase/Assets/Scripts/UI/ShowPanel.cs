using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.UI
{
	public class ShowPanel : MonoBehaviour
	{
		[field: SerializeField, Dropdown(StringCollectionNames.PanelsCollectionName)]
		private string PanelName { get; set; }
		[field: SerializeField]
		private bool ShowAtStart { get; set; }

		public void Show ()
		{
			UIManager.Instance.ShowPanel(PanelName);
		}

		private void Start ()
		{
			if (ShowAtStart)
			{
				Show();
			}
		}
	}
}