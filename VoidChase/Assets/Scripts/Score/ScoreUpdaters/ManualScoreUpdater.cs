namespace VoidChase.Score
{
	public class ManualScoreUpdater : BaseScoreUpdater
	{
		public void UpdateScore ()
		{
			ApplyScoreDifference(ScoreDifference);
		}
	}
}