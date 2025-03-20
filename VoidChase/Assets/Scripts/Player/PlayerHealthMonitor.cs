using System;
using UnityEngine;
using VoidChase.Modules;

namespace VoidChase.Player
{
	public class PlayerHealthMonitor : MonoBehaviour
	{
		public static event Action<int> PlayerHealthUpdated = delegate { };

		[field: SerializeField]
		private DestructibleModule BoundDestructibleModule { get; set; }

		private int InitialHealth => BoundDestructibleModule.InitialHealth;
		private int CurrentHealth => BoundDestructibleModule.Health;

		private void Start ()
		{
			BoundDestructibleModule.DamageTaken.AddListener(OnDamageTaken);
			PlayerHealthUpdated.Invoke(InitialHealth);
		}

		private void OnDestroy ()
		{
			BoundDestructibleModule.DamageTaken.RemoveListener(OnDamageTaken);
		}

		private void OnDamageTaken (int _)
		{
			PlayerHealthUpdated.Invoke(CurrentHealth);
		}
	}
}