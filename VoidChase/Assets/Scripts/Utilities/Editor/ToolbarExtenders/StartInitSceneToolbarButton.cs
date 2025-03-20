using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityToolbarExtender;

namespace VoidChase.Utilities.ToolbarExtenders
{
	[InitializeOnLoad]
	public static class StartInitSceneToolbarButton
	{
		private const string PreviousSceneKey = "PreviousScenePath";

		private static string PreviousScene
		{
			get => EditorPrefs.GetString(PreviousSceneKey, "");
			set => EditorPrefs.SetString(PreviousSceneKey, value);
		}

		static StartInitSceneToolbarButton ()
		{
			ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
		}

		private static void OnToolbarGUI ()
		{
			if (GUILayout.Button(new GUIContent("Start InitScene"), GUILayout.Width(100)))
			{
				StartGameScene();
			}
		}

		private static void StartGameScene ()
		{
			PreviousScene = SceneManager.GetActiveScene().path;
			string initScenePath = SceneUtility.GetScenePathByBuildIndex(0);

			if (string.IsNullOrEmpty(initScenePath))
			{
				Debug.LogError("Scene with index 0 has not been added to Build Settings!");
				return;
			}

			EditorSceneManager.OpenScene(initScenePath);
			EditorApplication.isPlaying = true;
		}

		private static void OnPlayModeStateChanged (PlayModeStateChange state)
		{
			if (state == PlayModeStateChange.EnteredEditMode)
			{
				string previousScenePath = PreviousScene;

				if (string.IsNullOrEmpty(previousScenePath))
				{
					return;
				}

				EditorSceneManager.OpenScene(previousScenePath);
				PreviousScene = null;
			}
		}
	}
}