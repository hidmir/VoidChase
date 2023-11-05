using UnityEngine;

namespace VoidChase.UI
{
	public class ShowPanel : MonoBehaviour
	{
		[SerializeField] private PanelType panelType;
		[SerializeField] private bool showAtStart;

		public void Show ()
		{
			UIManager.Instance.ShowPanel(panelType);
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