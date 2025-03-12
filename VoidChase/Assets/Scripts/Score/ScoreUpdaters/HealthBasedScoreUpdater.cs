namespace VoidChase.Score
{
	public class HealthBasedScoreUpdater : ManualScoreUpdater
	{
		public void UpdateScore (int damageTaken)
		{
			ApplyScoreDifference(damageTaken * ScoreDifference);
		}
	}
}