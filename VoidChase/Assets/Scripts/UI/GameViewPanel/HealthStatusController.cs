using System.Collections.Generic;
using UnityEngine;
using VoidChase.Player;

namespace VoidChase.UI.GameView
{
	public class HealthStatusController : MonoBehaviour
	{
		[field: SerializeField]
		private List<GameObject> HearthIcons { get; set; }

		private void Start ()
		{
			PlayerHealthMonitor.PlayerHealthUpdated += OnPlayerHealthUpdated;
		}

		private void OnDestroy ()
		{
			PlayerHealthMonitor.PlayerHealthUpdated -= OnPlayerHealthUpdated;
		}

		private void OnPlayerHealthUpdated (int health)
		{
			for (int i = 0; i < HearthIcons.Count; i++)
			{
				HearthIcons[i].SetActive(i < health);
			}
		}
	}
}