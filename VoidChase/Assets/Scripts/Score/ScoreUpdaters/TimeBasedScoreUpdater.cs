using UnityEngine;
using VoidChase.GameLoop.Pause;

namespace VoidChase.Score
{
	public class TimeBasedScoreUpdater : BaseScoreUpdater, IPausable
	{
		[field: SerializeField]
		private float TimeBetweenScoreUpdates { get; set; } = 1.0f;

		private bool isPaused;
		private float timeSinceLastUpdate;

		public void OnPause ()
		{
			isPaused = true;
		}

		public void OnResume ()
		{
			isPaused = false;
		}

		private void Start ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void Update ()
		{
			AttemptUpdateScore();
		}

		private void OnDestroy ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void AttemptUpdateScore ()
		{
			if (isPaused)
			{
				return;
			}

			if (timeSinceLastUpdate >= TimeBetweenScoreUpdates)
			{
				ApplyScoreDifference(ScoreDifference);
				timeSinceLastUpdate = 0.0f;
			}

			timeSinceLastUpdate += Time.deltaTime;
		}
	}
}