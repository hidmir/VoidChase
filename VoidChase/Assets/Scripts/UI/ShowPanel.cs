using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI
{
	public class ShowPanel : MonoBehaviour
	{
		[Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)] 
		[SerializeField] private string panelName;
		[SerializeField] private bool showAtStart;

		public void Show ()
		{
			UIManager.Instance.ShowPanel(panelName);
		}

		private void Start ()
		{
			if (showAtStart)
			{
				Show();
			}
		}
	}
}