using UnityEngine;

namespace VoidChase.Spaceship.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		public abstract void Shoot (Vector2 position);
	}
}