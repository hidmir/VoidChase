using UnityEngine;

namespace VoidChase.MovingObjects
{
	public abstract class BaseMovingObjectsSpawner : MonoBehaviour
	{
		public abstract void Spawn (Vector2 position, Vector2 direction);
	}
}