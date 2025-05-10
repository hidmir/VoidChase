using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.SceneManagement
{
	[Serializable]
	public class LevelData
	{
		[field: SerializeField]
		public SceneData SceneData { get; private set; }
		[field: SerializeField, Dropdown(StringCollectionNames.LevelsCollectionName)]
		public string LevelName { get; private set; }
	}
}