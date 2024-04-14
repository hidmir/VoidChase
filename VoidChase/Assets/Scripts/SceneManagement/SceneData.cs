using UnityEngine;
using VoidChase.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace VoidChase.SceneManagement
{
	[CreateAssetMenu(fileName = nameof(SceneData), menuName = MenuNames.SCENE_MANAGEMENT_PATH + nameof(SceneData))]
	public class SceneData : ScriptableObject, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[field: SerializeField]
		private SceneAsset BoundScene { get; set; }
#endif
		[field: SerializeField]
		public string ScenePath { get; private set; }

		public void OnBeforeSerialize ()
		{
#if UNITY_EDITOR
			ScenePath = BoundScene == null ? string.Empty : AssetDatabase.GetAssetPath(BoundScene);
#endif
		}

		public void OnAfterDeserialize () { }
	}
}