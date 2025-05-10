using UnityEngine;

namespace VoidChase.Audio
{
	public static class AudioUtilities
	{
		//Amplitude to dB conversion math formula
		//source: https://dspillustrations.com/pages/posts/misc/decibel-conversion-factor-10-or-factor-20.html
		public static float LinearTodB (float linear, float dBMinValue = -80.0f, float dBMaxValue = 0.0f)
		{
			return Mathf.Clamp(Mathf.Log10(linear) * 20.0f, dBMinValue, dBMaxValue);
		}
	}
}