using System;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
	[Serializable]
	public abstract class ObjectData<TKey, TObjectReference>
	{
		public abstract TKey Key { get; set; }
		[field: SerializeField]
		public TObjectReference ObjectReference { get; private set; }
	}
}