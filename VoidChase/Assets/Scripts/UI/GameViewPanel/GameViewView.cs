using UnityEngine;
using UnityEngine.UI;

namespace VoidChase.UI.GameView
{
	public class GameViewView : View
	{
		[SerializeField] private Button pauseButton;

		public void SetPauseButtonInteractionsState (bool isEnabled)
		{
			pauseButton.interactable = isEnabled;
		}
	}
}