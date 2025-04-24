using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

namespace VoidChase.UI
{
	public class ButtonAudioController : MonoBehaviour
	{
		[field: SerializeField]
		private Button BoundButton { get; set; }
		[field: SerializeField]
		private StudioEventEmitter ClickSound { get; set; }

		private void Start ()
		{
			BoundButton.onClick.AddListener(OnClick);
		}

		private void OnDestroy ()
		{
			BoundButton.onClick.RemoveListener(OnClick);
		}

		private void OnClick ()
		{
			ClickSound.Play();
		}
	}
}