using System;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
	[Serializable]
	public class ObjectData<TType, TObjectReference>
	{
		[field: SerializeField]
		public TType Type { get; private set; }
		[field: SerializeField]
		public TObjectReference ObjectReference { get; private set; }
	}
}