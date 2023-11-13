using System;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Weapons
{
	[Serializable]
	public class WeaponData : ObjectData<string, BaseWeapon>
	{
		[field: SerializeField, Dropdown(StringCollectionNames.WEAPONS_COLLECTION_NAME)]
		public override string Key { get; set; }
	}
}