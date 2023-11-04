using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.SceneManagement
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        [field: SerializeField]
        private string StartSceneName { get; set; }

        public float LoadingProgress { get; private set; }

        public void LoadSceneAsync (string sceneName)
        {
            StartCoroutine(LoadSceneProcess(sceneName));
        }

        protected virtual void Start ()
        {
            LoadSceneAsync(StartSceneName);
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
    }
}
