using UnityEngine;

namespace VoidChase.Score
{
	public class BaseScoreUpdater : MonoBehaviour
	{
		[field: SerializeField]
		protected int ScoreDifference { get; private set; }

		protected void ApplyScoreDifference (int scoreDifference)
		{
			ScoreManager.Instance.UpdateScore(scoreDifference);
		}
	}
}