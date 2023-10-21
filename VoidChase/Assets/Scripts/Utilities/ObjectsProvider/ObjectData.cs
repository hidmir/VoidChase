using System;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
	[Serializable]
	public class ObjectData<TObjectReference>
	{
		[field: SerializeField]
		public string Name { get; private set; }
		[field: SerializeField]
		public TObjectReference ObjectReference { get; private set; }
	}
}