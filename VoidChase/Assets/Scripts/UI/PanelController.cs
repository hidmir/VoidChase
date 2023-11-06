using UnityEngine;

namespace VoidChase.UI
{
	public class PanelController : MonoBehaviour
	{
		[SerializeField] private View currentView;

		public void SetVisibility (bool isVisible)
		{
			currentView.SetContentState(isVisible);
		}
	}
}