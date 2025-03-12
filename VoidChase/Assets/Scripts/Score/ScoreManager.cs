using System;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Score
{
	public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
	{
		public static event Action<int> ScoreChanged = delegate { };

		[field: SerializeField]
		private bool CanBeNegative { get; set; }

		public int CurrentScore { get; private set; }

		public void UpdateScore (int pointsDifference)
		{
			int newScore = CurrentScore + pointsDifference;

			if (newScore < 0 && !CanBeNegative)
			{
				newScore = 0;
			}

			CurrentScore = newScore;
			ScoreChanged.Invoke(CurrentScore);
		}

		protected override void Initialize ()
		{
			base.Initialize();
			ScoreChanged.Invoke(0);
		}
	}
}