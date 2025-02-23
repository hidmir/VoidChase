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
		static StartInitSceneToolbarButton ()
		{
			ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
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
			string scenePath = SceneUtility.GetScenePathByBuildIndex(0);

			if (string.IsNullOrEmpty(scenePath))
			{
				Debug.LogError("Scene with index 0 has not been added to Build Settings!");
				return;
			}

			EditorSceneManager.OpenScene(scenePath);
			EditorApplication.isPlaying = true;
		}
	}
}