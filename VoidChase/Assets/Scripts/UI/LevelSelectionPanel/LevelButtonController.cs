using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VoidChase.Utilities;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.UI.LevelSelection
{
	public class LevelButtonController : MonoBehaviour
	{
		[field: Header(InspectorNames.EVENTS_NAME)]
		[field: SerializeField]
		public UnityEvent<string> LevelStartRequested { get; private set; }

		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private GameObject ScoreParent { get; set; }
		[field: SerializeField]
		private TMP_Text ScoreValueText { get; set; }
		[field: SerializeField]
		private Button BoundButton { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField, Dropdown(StringCollectionNames.LevelsCollectionName)]
		private string LevelName { get; set; }

		public void UpdateDisplayedScore ()
		{
			string key = PrefsKeysGenerator.GetLevelScoreKey(LevelName);

			if (PlayerPrefs.HasKey(key))
			{
				int currentScore = PlayerPrefs.GetInt(key);

				ScoreParent.SetActive(true);
				ScoreValueText.text = currentScore.ToString();
			}
			else
			{
				ScoreParent.SetActive(false);
			}
		}

		private void Start ()
		{
			BoundButton.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy ()
		{
			BoundButton.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked ()
		{
			LevelStartRequested.Invoke(LevelName);
		}
	}
}