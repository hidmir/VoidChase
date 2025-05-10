using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Audio
{
	public class DebugAudioVisualization : MonoBehaviour
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private LineRenderer BoundLineRenderer { get; set; }
		[field: SerializeField]
		private FMODSpectrumDataAnalyzer BoundAnalyzer { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float Width { get; set; } = 10.0f;
		[field: SerializeField]
		private float Height { get; set; } = 0.1f;

		private void Start ()
		{
			Initialize();
		}

		private void Update ()
		{
			UpdateVisualization();
		}

		private void Initialize ()
		{
			BoundLineRenderer.positionCount = BoundAnalyzer.WindowSize;
		}

		private void UpdateVisualization ()
		{
			float[] spectrumData = BoundAnalyzer.GetSpectrumData();

			if (spectrumData == null)
			{
				return;
			}

			Vector3 position = Vector3.zero;
			position.x = Width * -0.5f;

			for (int index = 0; index < BoundAnalyzer.WindowSize; ++index)
			{
				float currentSpectrumData = spectrumData[index];
				position.x += Width / BoundAnalyzer.WindowSize;

				float soundLevel = AudioUtilities.LinearTodB(currentSpectrumData);
				position.y = (80 + soundLevel) * Height;

				BoundLineRenderer.SetPosition(index, position);
			}
		}
	}
}