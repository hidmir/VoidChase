using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.GameManagement
{
	public class GameSpeedController : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float SpeedGain { get; set; } = 0.05f;
		[field: SerializeField]
		private float IncreasingSpeedFrequency { get; set; } = 1.0f;

		public float CurrentSpeed { get; private set; } = 1.0f;
		private float TimeSinceLastSpeedGain { get; set; }

		protected virtual void Update ()
		{
			UpdateGameSpeed();
		}

		private void UpdateGameSpeed ()
		{
			TimeSinceLastSpeedGain += Time.deltaTime;

			if (CanIncreaseSpeed())
			{
				CurrentSpeed += SpeedGain;
				TimeSinceLastSpeedGain = 0.0f;
			}
		}

		private bool CanIncreaseSpeed ()
		{
			return TimeSinceLastSpeedGain > 1.0f / IncreasingSpeedFrequency;
		}
	}
}