using System;
using UnityEngine;

namespace VoidChase.Utilities.Dropdown
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DropdownAttribute : PropertyAttribute
	{
		public string SearchName { get; private set; }

		public DropdownAttribute (string searchName)
		{
			SearchName = searchName;
		}
	}
}