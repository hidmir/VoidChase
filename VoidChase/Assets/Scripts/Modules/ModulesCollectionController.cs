using System.Collections.Generic;
using UnityEngine;

namespace VoidChase.Modules
{
	public class ModulesCollectionController : MonoBehaviour
	{
		[field: SerializeField]
		private List<BaseModule> ModulesCollection { get; set; }

		public void InitializeModules ()
		{
			foreach (BaseModule module in ModulesCollection)
			{
				module.Initialize();
			}
		}
	}
}