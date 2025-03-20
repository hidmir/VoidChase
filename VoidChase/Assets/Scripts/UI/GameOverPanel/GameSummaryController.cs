using TMPro;
using UnityEngine;
using VoidChase.GameLoop;
using VoidChase.Score;
using VoidChase.Utilities;

namespace VoidChase.UI.GameSummary
{
	public class GameSummaryController : BasePanelController
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private TMP_Text ResultText { get; set; }
		[field: SerializeField]
		private TMP_Text ScoreValueText { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private string SuccessTextValue { get; set; }
		[field: SerializeField]
		private string FailureTextValue { get; set; }

		private GameLoopManager CurrentGameLoopManager => GameLoopManager.Instance;
		private ScoreManager CurrentScoreManager => ScoreManager.Instance;
		private const string MissingScoreValue = "???";

		public void ExitLevel ()
		{
			SetVisibility(false);
			CurrentGameLoopManager.ExitLevel();
		}

		protected override void OnShowPanel ()
		{
			base.OnShowPanel();
			UpdateResult();
			UpdateScore();
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			GameLoopManager.GameEnded += OnGameEnded;
		}

		private void DetachFromEvents ()
		{
			GameLoopManager.GameEnded -= OnGameEnded;
		}

		private void UpdateResult ()
		{
			bool isEndedWithSuccess = CurrentGameLoopManager != null && CurrentGameLoopManager.IsEndedWithSuccess;
			ResultText.text = isEndedWithSuccess ? SuccessTextValue : FailureTextValue;
		}

		private void UpdateScore ()
		{
			string score = CurrentScoreManager != null ? CurrentScoreManager.CurrentScore.ToString() : MissingScoreValue;
			ScoreValueText.text = score;
		}

		private void OnGameEnded ()
		{
			SetVisibility(true);
		}
	}
}