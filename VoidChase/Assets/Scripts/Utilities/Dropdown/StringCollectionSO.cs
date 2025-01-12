using System.Collections.Generic;
using UnityEngine;

namespace VoidChase.Utilities.Dropdown
{
	[CreateAssetMenu(fileName = nameof(StringCollectionSO), menuName = MenuNames.UTILITIES_PATH + nameof(StringCollectionSO))]
	public class StringCollectionSO : ScriptableObject
	{
		[field: SerializeField]
		public List<string> Collection { get; private set; }
	}
}