using System;

namespace VoidChase.Utilities
{
	public class CodeSharedVariable<TValue>
	{
		public event Action<TValue> CurrentValueChanged = delegate { };
		public event Action<TValue, TValue> ValueChanged = delegate { };

		public TValue Value
		{
			get => currentValue;
			set
			{
				if (!Equals(currentValue, value))
				{
					TValue oldValue = currentValue;
					currentValue = value;

					CurrentValueChanged.Invoke(currentValue);
					ValueChanged.Invoke(oldValue, currentValue);
				}
			}
		}

		private TValue currentValue;
	}
}