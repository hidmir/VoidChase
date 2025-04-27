using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using VoidChase.PauseManagement;

namespace VoidChase.Audio
{
	public class BackgroundMusicController : MonoBehaviour, IPausable
	{
		[field: SerializeField]
		private StudioEventEmitter BoundAudio { get; set; }

		public EventInstance CurrentSound => BoundAudio.EventInstance;

		public void OnPause ()
		{
			CurrentSound.setVolume(0.0f);
			CurrentSound.setPaused(true);
		}

		public void OnResume ()
		{
			CurrentSound.setPaused(false);
			CurrentSound.setVolume(1.0f);
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