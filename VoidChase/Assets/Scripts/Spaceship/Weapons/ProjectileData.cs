using System;
using UnityEngine;

namespace VoidChase.Spaceship.Weapons
{
	[Serializable]
	public class ProjectileData
	{
		[field: SerializeField]
		public Vector2 PositionOffset { get; private set; }
		[field: SerializeField]
		public Vector2 Direction { get; private set; }
	}
}