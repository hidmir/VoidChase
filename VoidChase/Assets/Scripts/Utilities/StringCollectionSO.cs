using System.Collections.Generic;
using UnityEngine;
using VoidChase.Utilities;

[CreateAssetMenu(fileName = nameof(StringCollectionSO), menuName = MenuNames.SCRIPTABLE_OBJECTS_PATH + nameof(StringCollectionSO))]
public class StringCollectionSO : ScriptableObject
{
	[field: SerializeField]
	public List<string> Collection { get; private set; }
}