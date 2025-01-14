using UnityEngine;
using VoidChase.Utilities;
using VoidChase.Utilities.Attributes;

namespace VoidChase.Environment.GameSpeed
{
	[CreateAssetMenu(fileName = nameof(GameSpeedSO), menuName = MenuNames.ENVIRONMENT_PATH + nameof(GameSpeedSO))]
	public class GameSpeedSO : ScriptableObject
	{
		[field: SerializeField, ReadOnly]
		public float CurrentSpeed { get; set; } = DefaultSpeedValue;

		public const float DefaultSpeedValue = 1.0f;
	}
}