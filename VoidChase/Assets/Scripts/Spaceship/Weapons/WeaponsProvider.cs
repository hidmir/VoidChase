using System.Collections.Generic;
using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Weapons
{
	public class WeaponsProvider : SingletonMonoBehaviour<WeaponsProvider>
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private List<WeaponData> WeaponDataCollection { get; set; }

		private Dictionary<string, BaseWeapon> WeaponsMap { get; set; }

		private const string WEAPON_NOT_FOUND_MESSAGE = "Cannot find weapon with name {0}.";

		public bool TryGetWeapon (string weaponName, out BaseWeapon weapon)
		{
			weapon = null;

			if (!WeaponsMap.TryGetValue(weaponName, out weapon))
			{
				Debug.LogError(string.Format(WEAPON_NOT_FOUND_MESSAGE, weaponName));
			}

			return weapon != null;
		}

		protected override void Initialize ()
		{
			base.Initialize();
			ConvertWeaponDataToDictionary();
		}

		private void ConvertWeaponDataToDictionary ()
		{
			foreach (WeaponData weaponData in WeaponDataCollection)
			{
				WeaponsMap.Add(weaponData.Name, weaponData.Weapon);
			}
		}
	}
}