using System;
using UnityEngine;
using VoidChase.Modules;
using VoidChase.Utilities;

namespace VoidChase.Projectiles
{
	public class ProjectileController : MonoBehaviour
	{
		public event Action<ProjectileController> RequestDestroying = delegate { };

		[field: Header(InspectorNames.REFERENCES_NAME)]
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