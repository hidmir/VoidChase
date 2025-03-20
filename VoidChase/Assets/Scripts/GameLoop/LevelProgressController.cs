using System;
using UnityEngine;
using VoidChase.GameLoop.Pause;

namespace VoidChase.GameLoop
{
	public class LevelProgressController : MonoBehaviour, IPausable
	{
		public event Action MaxProgressReached = delegate { };

		[field: SerializeField, Min(0.0f)]
		private float LevelDuration { get; set; } = 30.0f;

		private bool isPaused;
		private bool isMaxProgressReached;
		private float elapsedTime;

		public void OnPause ()
		{
			isPaused = true;
		}

		public void OnResume ()
		{
			isPaused = false;
		}

		public float GetProgress ()
		{
			return elapsedTime / LevelDuration;
		}

		private void Start ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void Update ()
		{
			UpdateProgress();
		}

		private void OnDestroy ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void UpdateProgress ()
		{
			if (isPaused || isMaxProgressReached)
			{
				return;
			}

			elapsedTime += Time.deltaTime;

			if (elapsedTime > LevelDuration)
			{
				isMaxProgressReached = true;
				MaxProgressReached.Invoke();
			}
		}
	}
}