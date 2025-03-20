using System.Collections.Generic;
using UnityEngine;
using VoidChase.MovingObjects;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Weapons
{
	public class ProjectilesWeapon : BaseWeapon
	{
		[field: Header("Projectiles Settings")]
		[field: SerializeField]
		private List<ProjectileData> ProjectilesDataCollection { get; set; }

		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private BaseMovingObjectsSpawner CurrentMovingObjectsSpawner { get; set; }

		protected override void OnFire (Vector2 position)
		{
			foreach (ProjectileData projectileData in ProjectilesDataCollection)
			{
				CurrentMovingObjectsSpawner.Spawn(position + projectileData.PositionOffset, projectileData.Direction);
			}
		}
	}
}