using System;
using UnityEngine;

namespace VoidChase.SceneManagement
{
	[Serializable]
	public class LevelData
	{
		[field: SerializeField]
		public SceneData SceneData { get; private set; }
		[field: SerializeField, Min(1)]
		public int Number { get; private set; } = 1;
	}
}