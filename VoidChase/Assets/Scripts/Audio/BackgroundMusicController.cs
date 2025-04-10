using FMODUnity;
using UnityEngine;
using VoidChase.PauseManagement;

namespace VoidChase.Audio
{
	public class BackgroundMusicController : MonoBehaviour, IPausable
	{
		[field: SerializeField]
		private StudioEventEmitter BoundAudio { get; set; }

		public void OnPause ()
		{
			BoundAudio.EventInstance.setPaused(true);
		}

		public void OnResume ()
		{
			BoundAudio.EventInstance.setPaused(false);
		}

		private void OnEnable ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			((IPausable) this).UnregisterPausable();
		}
	}
}