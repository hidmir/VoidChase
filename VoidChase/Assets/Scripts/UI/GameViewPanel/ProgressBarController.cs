using UnityEngine;
using UnityEngine.UI;
using VoidChase.GameLoop;
using VoidChase.Utilities;

namespace VoidChase.UI.GameView
{
	public class ProgressBarController : MonoBehaviour
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private Image FillImage { get; set; }
		[field: SerializeField]
		private RectTransform SpaceshipImage { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private Vector2 AnimationStartPosition { get; set; } = new (-256.0f, 0);
		[field: SerializeField]
		private Vector2 AnimationEndPosition { get; set; } = new (256.0f, 0);

		private GameLoopManager CurrentGameLoopManager => GameLoopManager.Instance;

		private void Update ()
		{
			UpdateProgress();
		}

		private void UpdateProgress ()
		{
			if (CurrentGameLoopManager == null)
			{
				return;
			}

			float levelProgress = CurrentGameLoopManager.GetLevelProgress;
			FillImage.fillAmount = levelProgress;

			SpaceshipImage.anchoredPosition = Vector2.Lerp(AnimationStartPosition, AnimationEndPosition, levelProgress);
		}
	}
}