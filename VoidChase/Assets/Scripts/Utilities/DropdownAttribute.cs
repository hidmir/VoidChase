using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class DropdownAttribute : PropertyAttribute
{
	public string SearchName { get; private set; }

	public DropdownAttribute (string searchName)
	{
		SearchName = searchName;
	}
}