using System;
using System.Collections.Generic;
using UnityEngine;
using VoidChase.Player;
using VoidChase.Utilities.Dropdown;

namespace VoidChase.UI.GameView
{
	public class CurrentWeaponDisplayController : MonoBehaviour
	{
		[field: SerializeField]
		private List<WeaponVisualizationData> WeaponDisplayCollection { get; set; }

		private void Start ()
		{
			WeaponMonitor.PlayerWeaponUpdated += OnPlayerWeaponUpdated;
		}

		private void OnDestroy ()
		{
			WeaponMonitor.PlayerWeaponUpdated -= OnPlayerWeaponUpdated;
		}

		private void OnPlayerWeaponUpdated (string newWeapon)
		{
			foreach (WeaponVisualizationData visualizationData in WeaponDisplayCollection)
			{
				bool isVisible = visualizationData.WeaponName == newWeapon;
				visualizationData.BoundObject.SetActive(isVisible);
			}
		}

		[Serializable]
		private class WeaponVisualizationData
		{
			[field: SerializeField, Dropdown(StringCollectionNames.WeaponsCollectionName)]
			public string WeaponName { get; private set; }
			[field: SerializeField]
			public GameObject BoundObject { get; private set; }
		}
	}
}