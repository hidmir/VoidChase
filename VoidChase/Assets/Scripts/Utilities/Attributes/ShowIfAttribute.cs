using UnityEngine;

namespace VoidChase.Utilities.Attributes
{
	public class ShowIfAttribute : PropertyAttribute
	{
		public string ConditionName { get; }

		public ShowIfAttribute (string conditionName)
		{
			ConditionName = conditionName;
		}
	}
}