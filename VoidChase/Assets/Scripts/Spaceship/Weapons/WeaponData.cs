using System;
using UnityEngine;

namespace VoidChase.Spaceship.Weapons
{
	[Serializable]
	public class WeaponData
	{
		[field: SerializeField]
		public string Name { get; private set; }
		[field: SerializeField]
		public BaseWeapon Weapon { get; private set; }
	}
}