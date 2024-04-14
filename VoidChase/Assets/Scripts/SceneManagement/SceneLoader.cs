using System.Collections;
using System.Collections.Generic;
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

        private const string CANNOT_LOAD_LEVEL = "Level cannot be loaded because there is no scene data with number {0}.";

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
                Debug.LogError(string.Format(CANNOT_LOAD_LEVEL, levelNumber.ToString()));
            }
        }

        public void LoadSceneAsync (string sceneName)
        {
            StartCoroutine(LoadSceneProcess(sceneName));
        }

        protected virtual void Start ()
        {
            LoadMainMenuScene ();
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
            scenePath = string.Empty;
            
            for (int index = 0; index < levelDataCollection.Count; index++)
            {
                LevelData levelData = levelDataCollection[index];

                if (levelData.Number == levelNumber)
                {
                    scenePath = levelData.SceneData.ScenePath;
                    break;
                }
            }

            return scenePath != string.Empty;
        }
    }
}
