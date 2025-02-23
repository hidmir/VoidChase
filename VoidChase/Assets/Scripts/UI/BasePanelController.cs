using UnityEngine;

namespace VoidChase.UI
{
	public class BasePanelController : MonoBehaviour
	{
		[field: SerializeField]
		protected CanvasGroup Content { get; private set; }

		public void SetVisibility (bool isVisible)
		{
			Content.interactable = isVisible;
			Content.blocksRaycasts = isVisible;
			Content.alpha = isVisible ? 1.0f : 0.0f;
		}
	}
}