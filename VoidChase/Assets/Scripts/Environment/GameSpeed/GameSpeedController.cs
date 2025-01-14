using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Environment.GameSpeed
{
	public class GameSpeedController : MonoBehaviour
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private GameSpeedSO GameSpeedSO { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float SpeedGain { get; set; } = 0.05f;
		[field: SerializeField]
		private float IncreasingSpeedFrequency { get; set; } = 1.0f;

		private float TimeSinceLastSpeedGain { get; set; }

		private void Awake ()
		{
			GameSpeedSO.CurrentSpeed = GameSpeedSO.DefaultSpeedValue;
		}

		private void Update ()
		{
			UpdateGameSpeed();
		}

		private void UpdateGameSpeed ()
		{
			TimeSinceLastSpeedGain += Time.deltaTime;

			if (CanIncreaseSpeed())
			{
				GameSpeedSO.CurrentSpeed += SpeedGain;
				TimeSinceLastSpeedGain = 0.0f;
			}
		}

		private bool CanIncreaseSpeed ()
		{
			return TimeSinceLastSpeedGain > 1.0f / IncreasingSpeedFrequency;
		}
	}
}