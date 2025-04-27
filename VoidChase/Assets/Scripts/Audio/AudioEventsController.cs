using System;
using System.Runtime.InteropServices;
using FMOD;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace VoidChase.Audio
{
	public class AudioEventsController : MonoBehaviour
	{
		public static event Action<int> AudioEventInvoked = delegate { };

		[field: SerializeField]
		private BackgroundMusicController BoundBackgroundMusicController { get; set; }

		private GCHandle callbackHandle;

		private void Start ()
		{
			FMOD.Studio.EVENT_CALLBACK callback = MarkerCallback;
			callbackHandle = GCHandle.Alloc(callback);

			BoundBackgroundMusicController.CurrentSound.setCallback(callback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
		}

		private void OnDestroy ()
		{
			if (callbackHandle.IsAllocated)
			{
				callbackHandle.Free();
			}
		}

		[AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
		private static RESULT MarkerCallback (FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
		{
			if (type == FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER)
			{
				FMOD.Studio.TIMELINE_MARKER_PROPERTIES marker = (FMOD.Studio.TIMELINE_MARKER_PROPERTIES) Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_MARKER_PROPERTIES));

				string name = marker.name;
				int index = ConvertMarkerToIndex(name);

				AudioEventInvoked.Invoke(index);
				Debug.Log($"[FMOD] Marker triggered: {name}, index: {index.ToString()}");
			}

			return RESULT.OK;
		}

		private static int ConvertMarkerToIndex (string markerName)
		{
			if (!string.IsNullOrWhiteSpace(markerName) && markerName.Length > 1)
			{
				char markerIdentifier = markerName[^1];

				if (char.IsLetter(markerIdentifier))
				{
					markerIdentifier = char.ToUpperInvariant(markerIdentifier);

					if (markerIdentifier is >= 'A' and <= 'Z')
					{
						return markerIdentifier - 'A';
					}
				}
			}

			return -1;
		}
	}
}