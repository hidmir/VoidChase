using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.SceneManagement
{
	public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
	{
		[SerializeField] private SceneData mainMenuSceneData;
		[SerializeField] private List<LevelData> levelDataCollection;

		public float LoadingProgress { get; private set; }

		public void LoadMainMenuScene ()
		{
			LoadSceneAsync(mainMenuSceneData.ScenePath);
		}

		public void LoadLevelScene (int levelNumber)
		{
			if (TryGetLevelScenePath(out string scenePath, levelNumber))
			{
				LoadSceneAsync(scenePath);
			}
			else
			{
				Debug.LogError($"Level cannot be loaded because there is no scene data with number {levelNumber.ToString()}.");
			}
		}

		private void Start ()
		{
			LoadMainMenuScene();
		}

		private void LoadSceneAsync (string sceneName)
		{
			StartCoroutine(LoadSceneProcess(sceneName));
		}

		private IEnumerator LoadSceneProcess (string sceneName)
		{
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

			while (!asyncOperation.isDone)
			{
				LoadingProgress = asyncOperation.progress;
				yield return null;
			}

			LoadingProgress = 1.0f;
		}

		private bool TryGetLevelScenePath (out string scenePath, int levelNumber)
		{
			scenePath = levelDataCollection.FirstOrDefault(levelData => levelData.Number == levelNumber)?.SceneData.ScenePath;
			return scenePath != string.Empty;
		}
	}
}