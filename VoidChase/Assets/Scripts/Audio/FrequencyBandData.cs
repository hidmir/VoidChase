using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.Audio
{
	[Serializable]
	public class FrequencyBandData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.FrequencyBandsCollectionName)]
		public string Name { get; private set; }
		[field: SerializeField]
		public float MinFrequency { get; private set; }
		[field: SerializeField]
		public float MaxFrequency { get; private set; }
	}
}