using UnityEngine;

namespace VoidChase.UI
{
	public class Controller<TModel, TView> : MonoBehaviour
		where TModel : Model<TView>
		where TView : View
	{
		[field: SerializeField]
		protected TView CurrentView { get; private set; }
		[field: SerializeField]
		protected TModel CurrentModel { get; private set; }
	}
}