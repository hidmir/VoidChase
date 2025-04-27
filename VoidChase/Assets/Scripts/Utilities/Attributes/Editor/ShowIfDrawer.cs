using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VoidChase.Utilities.Attributes
{
	[CustomPropertyDrawer(typeof(ShowIfAttribute))]
	public class ShowIfDrawer : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			ShowIfAttribute showIf = (ShowIfAttribute) attribute;
			Object target = property.serializedObject.targetObject;

			if (IsConditionMet(showIf.ConditionName, target))
			{
				EditorGUI.PropertyField(position, property, label, true);
			}
		}

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			ShowIfAttribute showIf = (ShowIfAttribute) attribute;
			Object target = property.serializedObject.targetObject;

			if (!IsConditionMet(showIf.ConditionName, target))
			{
				return 0.0f;
			}

			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		private bool IsConditionMet (string conditionName, object target)
		{
			Type type = target.GetType();
			MethodInfo method = type.GetMethod(conditionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

			if (method != null && method.ReturnType == typeof(bool))
			{
				return (bool) method.Invoke(target, null);
			}

			FieldInfo field = type.GetField(conditionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			if (field != null && field.FieldType == typeof(bool))
			{
				return (bool) field.GetValue(target);
			}

			PropertyInfo property = type.GetProperty(conditionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			if (property != null && property.PropertyType == typeof(bool) && property.GetGetMethod(true) != null)
			{
				return (bool) property.GetValue(target);
			}

			Debug.LogWarning($"[ShowIf] Cannot find method/field/property bool with name '{conditionName}' in {type.Name}");
			return true;
		}
	}
}