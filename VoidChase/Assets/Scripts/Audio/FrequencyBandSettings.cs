using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Audio
{
	[CreateAssetMenu(fileName = nameof(FrequencyBandSettings), menuName = MenuNames.AUDIO_PATH + nameof(FrequencyBandSettings))]
	public class FrequencyBandSettings : ScriptableObject
	{
		[field: SerializeField]
		private List<FrequencyBandData> FrequencyBandDataCollection { get; set; }

		public FrequencyBandData GetFrequencyBandData (string frequencyBandName)
		{
			return FrequencyBandDataCollection.FirstOrDefault(data => string.Equals(data.Name, frequencyBandName, StringComparison.InvariantCulture));
		}
	}
}