using UnityEngine;

namespace VoidChase.MovingObjects
{
	public abstract class BaseMovingObjectsSpawner : MonoBehaviour
	{
		public abstract void Spawn (Vector3 position, Vector3 direction);
	}
}