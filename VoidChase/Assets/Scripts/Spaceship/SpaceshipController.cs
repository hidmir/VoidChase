using UnityEngine;
using VoidChase.GameManagement;
using VoidChase.Modules;

namespace VoidChase.Spaceship
{
	public class SpaceshipController : MonoBehaviour
	{
		[SerializeField] private ModulesCollectionController currentModulesCollectionController;

		public void KillPlayer ()
		{
			GameManager.Instance.EndGame();
		}

		private void Start ()
		{
			currentModulesCollectionController.InitializeModules();
		}
	}
}