using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Weapons
{
	public class WeaponsProvider : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private List<WeaponData> WeaponDataCollection { get; set; }

		public bool TryGetWeapon (string weaponName, out BaseWeapon weapon)
		{
			weapon = WeaponDataCollection.FirstOrDefault(weaponData => weaponData.Name == weaponName)?.ObjectReference;

			if (weapon == null)
			{
				Debug.LogError($"Cannot find weapon with name {weaponName}.");
			}

			return weapon != null;
		}
	}
}