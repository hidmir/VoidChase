using System.Collections.Generic;
using UnityEngine;
using VoidChase.SceneManagement;

namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionController : BasePanelController
	{
		[field: SerializeField]
		private List<LevelButtonController> LevelButtons { get; set; }

		public void ShowMainMenu ()
		{
			SetVisibility(false);
			UIManager.Instance.ShowPanel(PanelsNames.MainMenu);
		}

		protected override void OnShowPanel ()
		{
			base.OnShowPanel();

			foreach (LevelButtonController levelButton in LevelButtons)
			{
				levelButton.UpdateDisplayedScore();
			}
		}

		private void Start ()
		{
			for (int index = 0; index < LevelButtons.Count; index++)
			{
				LevelButtonController levelButton = LevelButtons[index];
				levelButton.LevelStartRequested.AddListener(OnLevelStartRequested);
			}
		}

		private void OnDestroy ()
		{
			for (int index = 0; index < LevelButtons.Count; index++)
			{
				LevelButtonController levelButton = LevelButtons[index];
				levelButton.LevelStartRequested.RemoveListener(OnLevelStartRequested);
			}
		}

		private void OnLevelStartRequested (string levelName)
		{
			SetVisibility(false);
			SceneLoader.Instance.LoadLevelScene(levelName);
		}
	}
}