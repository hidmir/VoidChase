using System.Collections.Generic;
using UnityEngine;
using VoidChase.MovingObjects;
using VoidChase.Utilities;

namespace VoidChase.Spaceship.Weapons
{
	public class ProjectilesWeapon : BaseWeapon
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private BaseMovingObjectsSpawner CurrentMovingObjectsSpawner { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private List<ProjectileData> ProjectilesDataCollection { get; set; }

		public override void Shoot (Vector3 position)
		{
			foreach (ProjectileData projectileData in ProjectilesDataCollection)
			{
				CurrentMovingObjectsSpawner.Spawn(position + projectileData.PositionOffset, projectileData.Direction);
			}
		}
	}
}