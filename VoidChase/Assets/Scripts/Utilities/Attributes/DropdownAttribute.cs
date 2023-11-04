using UnityEngine;

public class DropdownAttribute : PropertyAttribute
{
	public string MethodName { get; private set; }

	public DropdownAttribute(string methodName)
	{
		MethodName = methodName;
	}
}