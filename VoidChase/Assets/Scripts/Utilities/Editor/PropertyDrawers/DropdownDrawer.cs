using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

[CustomPropertyDrawer(typeof(DropdownAttribute))]
public class DropdownDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		DropdownAttribute dropdown = attribute as DropdownAttribute;
		MethodInfo methodInfo = fieldInfo.DeclaringType.GetMethod(dropdown.MethodName,
			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        
		if (methodInfo != null)
		{
			object result = methodInfo.Invoke(property.serializedObject.targetObject, null);
			
			string[] items = null;

			if (result is IList<string> list)
			{
				items = list.ToArray();
			}

			if (property.propertyType == SerializedPropertyType.String && items != null)
			{
				int index = Mathf.Max(0, System.Array.IndexOf(items, property.stringValue));
				index = EditorGUI.Popup(position, label.text, index, items);
				property.stringValue = items[index];
			}
			else
			{
				EditorGUI.LabelField(position, label.text, "Use Dropdown with method returning collection.");
			}
		}
		else
		{
			EditorGUI.LabelField(position, label.text, $"Method {dropdown.MethodName} not found.");
		}
	}
}