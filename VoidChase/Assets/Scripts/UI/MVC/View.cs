using UnityEngine;

namespace VoidChase.UI
{
	public class View : MonoBehaviour
	{
		[field: SerializeField]
		protected GameObject Content { get; private set; }

		public void SetContentState (bool isEnabled)
		{
			Content.SetActive(isEnabled);
		}
	}
}