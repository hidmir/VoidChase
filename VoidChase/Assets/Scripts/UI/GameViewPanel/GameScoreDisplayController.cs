using TMPro;
using UnityEngine;
using VoidChase.Score;

namespace VoidChase.UI.GameView
{
	public class GameScoreDisplayController : MonoBehaviour
	{
		[field: SerializeField]
		private TMP_Text ScoreText { get; set; }

		private void Start ()
		{
			ScoreManager.ScoreChanged += OnScoreChanged;
		}

		private void OnDestroy ()
		{
			ScoreManager.ScoreChanged -= OnScoreChanged;
		}

		private void OnScoreChanged (int newScore)
		{
			ScoreText.text = newScore.ToString();
		}
	}
}