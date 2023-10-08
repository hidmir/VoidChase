using UnityEngine;

namespace VoidChase.Utilities
{
	public static class LayerUtilities
	{
		public static bool IsEqual (LayerMask firstLayer, int layerNumber)
		{
			return Mathf.Approximately(Mathf.Pow(2, layerNumber), firstLayer);
		}
	}
}