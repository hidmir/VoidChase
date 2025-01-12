using UnityEngine;

namespace VoidChase.UI
{
	public class BasePanelController : MonoBehaviour
	{
		[field: SerializeField]
		protected GameObject Content { get; private set; }

		public void SetVisibility (bool isVisible)
		{
			Content.SetActive(isVisible);
		}
	}
}