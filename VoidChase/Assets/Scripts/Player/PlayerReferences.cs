using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Player
{
	public class PlayerReferences : SingletonMonoBehaviour<PlayerReferences>
	{
		[field: SerializeField]
		public ParticleSystem DestructionEffect { get; private set; }
		[field: SerializeField]
		public GameObject PlayerModel { get; private set; }
		[field: SerializeField]
		public SpriteRenderer ThrusterFlameImage { get; private set; }
	}
}