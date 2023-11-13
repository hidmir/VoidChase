using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringCollectionSO", menuName = "VoidChase/ScriptableObjects/StringCollectionSO")]
public class StringCollectionSO : ScriptableObject
{
	[field: SerializeField]
	public List<string> Collection { get; private set; }
}