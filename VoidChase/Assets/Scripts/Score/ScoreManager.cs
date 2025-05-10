using System;
using UnityEngine;
using VoidChase.Utilities;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.Score
{
	public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
	{
		public static event Action<int> ScoreChanged = delegate { };

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField, Dropdown(StringCollectionNames.LevelsCollectionName)]
		private string LevelName { get; set; }
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

		public void AttemptSaveScore ()
		{
			string key = PrefsKeysGenerator.GetLevelScoreKey(LevelName);
			int bestScore = PlayerPrefs.GetInt(key);

			if (CurrentScore > bestScore)
			{
				PlayerPrefs.SetInt(key, CurrentScore);
			}
		}

		protected override void Initialize ()
		{
			base.Initialize();
			ScoreChanged.Invoke(0);
		}
	}
}