using UnityEngine;

namespace VoidChase.UI
{
	public class Model<TView> : MonoBehaviour where TView : View
	{
		[field: SerializeField]
		protected TView CurrentView { get; private set; }
	}
}