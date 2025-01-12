using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VoidChase.Utilities.Dropdown
{
	[CustomPropertyDrawer(typeof(DropdownAttribute))]
	public class DropdownDrawer : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			if (property.propertyType != SerializedPropertyType.String)
			{
				EditorGUI.LabelField(position, label.text, "Use Dropdown with string.");
				return;
			}

			DropdownAttribute dropdown = attribute as DropdownAttribute;

			string[] guids = AssetDatabase.FindAssets($"t:{nameof(StringCollectionSO)}");
			StringCollectionSO targetSO = null;

			foreach (string guid in guids)
			{
				string path = AssetDatabase.GUIDToAssetPath(guid);
				StringCollectionSO collectionSO = AssetDatabase.LoadAssetAtPath<StringCollectionSO>(path);

				if (collectionSO.name == dropdown.SearchName)
				{
					targetSO = collectionSO;
					break;
				}
			}

			List<string> options = targetSO != null ? targetSO.Collection : new List<string> { "None" };
			int currentIndex = !string.IsNullOrEmpty(property.stringValue) ? options.IndexOf(property.stringValue) : 0;
			currentIndex = Mathf.Max(currentIndex, 0);
			int selectedIndex = EditorGUI.Popup(position, label.text, currentIndex, options.ToArray());

			property.stringValue = (selectedIndex >= 0 && selectedIndex < options.Count) ? options[selectedIndex] : string.Empty;
		}
	}
}