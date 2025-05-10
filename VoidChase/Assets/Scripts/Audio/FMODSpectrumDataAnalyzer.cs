using System;
using System.Runtime.InteropServices;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using VoidChase.Utilities;
using Debug = UnityEngine.Debug;

namespace VoidChase.Audio
{
	public class FMODSpectrumDataAnalyzer : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private string AudioBusPath { get; set; } = "bus:/";
		[field: SerializeField]
		public int WindowSize { get; private set; } = 256;
		[field: SerializeField]
		private DSP_FFT_WINDOW_TYPE WindowType { get; set; } = DSP_FFT_WINDOW_TYPE.HANNING;

		[NonSerialized]
		private float[] spectrumData;
		private DSP digitalSoundProcessor;
		private Bus selectedBus;

		public float[] GetSpectrumData ()
		{
			return spectrumData;
		}

		private void Start ()
		{
			InitializeSoundProcessor();
		}

		private void Update ()
		{
			ProcessAudio();
		}

		private void OnDestroy ()
		{
			RemoveSoundProcessor();
		}

		private void InitializeSoundProcessor ()
		{
			RESULT createDSPResult = RuntimeManager.CoreSystem.createDSPByType(DSP_TYPE.FFT, out digitalSoundProcessor);

			if (createDSPResult != RESULT.OK)
			{
				Debug.LogError($"Cannot create {DSP_TYPE.FFT} with result: {createDSPResult}");
				return;
			}

			digitalSoundProcessor.setParameterInt((int) DSP_FFT.WINDOW, (int) WindowType);
			digitalSoundProcessor.setParameterInt((int) DSP_FFT.WINDOWSIZE, WindowSize * 2);

			selectedBus = RuntimeManager.GetBus(AudioBusPath);
			RESULT lockBusResult = selectedBus.lockChannelGroup();

			if (lockBusResult != RESULT.OK)
			{
				Debug.LogError($"Cannot lock bus with result: {lockBusResult}");
				return;
			}

			RuntimeManager.StudioSystem.flushCommands();

			if (!selectedBus.hasHandle())
			{
				Debug.LogError("Cannot get the selected bus.");
				return;
			}

			RESULT selectBusResult = selectedBus.getChannelGroup(out ChannelGroup channelGroup);

			if (selectBusResult != RESULT.OK)
			{
				Debug.LogError($"Cannot get Channel Group from the selected bus with result: {selectBusResult}");
				return;
			}

			RESULT addDSPResult = channelGroup.addDSP(CHANNELCONTROL_DSP_INDEX.HEAD, digitalSoundProcessor);

			if (addDSPResult != RESULT.OK)
			{
				Debug.LogError($"Cannot add FFT to the selected channel group with result: {addDSPResult}");
			}
		}

		private void ProcessAudio ()
		{
			if (!digitalSoundProcessor.hasHandle())
			{
				return;
			}

			if (digitalSoundProcessor.getParameterData((int) DSP_FFT.SPECTRUMDATA, out IntPtr unmanagedData, out uint length) == RESULT.OK)
			{
				DSP_PARAMETER_FFT fftData = (DSP_PARAMETER_FFT) Marshal.PtrToStructure(unmanagedData, typeof(DSP_PARAMETER_FFT));

				if (fftData.numchannels > 0)
				{
					spectrumData ??= new float[fftData.length];
					fftData.getSpectrum(0, ref spectrumData);
				}
			}
		}

		private void RemoveSoundProcessor ()
		{
			if (selectedBus.hasHandle() && selectedBus.getChannelGroup(out ChannelGroup channelGroup) == RESULT.OK && digitalSoundProcessor.hasHandle())
			{
				channelGroup.removeDSP(digitalSoundProcessor);
			}

			selectedBus.unlockChannelGroup();
		}
	}
}