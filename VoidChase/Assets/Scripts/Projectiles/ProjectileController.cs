using System;
using System.Collections.Generic;
using UnityEngine;
using VoidChase.Modules;

namespace VoidChase.Projectiles
{
	public class ProjectileController : MonoBehaviour
	{
		public event Action<ProjectileController> RequestDestroying = delegate { };
		
		[field: SerializeField]
		private ProjectileMovementBehaviour CurrentMovementBehaviour { get; set; }
		[field: SerializeField]
		private ModulesCollectionController CurrentModulesCollectionController { get; set; }

		public void Initialize ()
		{
			CurrentMovementBehaviour.Initialize();
			CurrentModulesCollectionController.InitializeModules();
		}

		public void DeInitialize ()
		{
			CurrentMovementBehaviour.DeInitialize();
		}

		public void Launch (Vector3 position, Vector3 direction)
		{
			CurrentMovementBehaviour.Launch(position, direction);
		}

		public void InvokeRequestDestroying ()
		{
			RequestDestroying.Invoke(this);
		}
	}
}