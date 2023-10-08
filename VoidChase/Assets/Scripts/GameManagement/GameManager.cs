using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.GameManagement
{
	public class GameManager : SingletonMonoBehaviour<GameManager>
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		public SceneBoundariesController CurrentSceneBoundariesController { get; private set; }
		[field: SerializeField]
		public GameSpeedController CurrentGameSpeedController { get; private set; }
	}
}