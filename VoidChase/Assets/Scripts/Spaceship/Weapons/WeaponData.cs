using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.Spaceship.Weapons
{
	[Serializable]
	public class WeaponData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.WEAPONS_COLLECTION_NAME)]
		public string Name { get; private set; }
		[field: SerializeField]
		public BaseWeapon ObjectReference { get; private set; }
	}
}