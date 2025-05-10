using System;
using UnityEngine;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.Weapons
{
	[Serializable]
	public class WeaponData
	{
		[field: SerializeField, Dropdown(StringCollectionNames.WeaponsCollectionName)]
		public string Name { get; private set; }
		[field: SerializeField]
		public BaseWeapon ObjectReference { get; private set; }
	}
}