using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.Environment.SceneBoundaries
{
	public class SceneBoundariesController : MonoBehaviour
	{
		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private SceneBoundariesSO SceneBoundariesSO { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private Vector3 CentralPoint { get; set; }
		[field: SerializeField]
		private Vector2 BoundariesSize { get; set; }

		[field: Header(InspectorNames.VISUALIZATION_NAME)]
		[field: SerializeField]
		private Color VisualizationColor { get; set; } = Color.yellow;

		private void Awake ()
		{
			SceneBoundariesSO.SetPositionLimits(GetMaxXPosition(), GetMinXPosition(), GetMaxYPosition(), GetMinYPosition());
			SceneBoundariesSO.SetBoundariesCorners(GetTopLeftCorner(), GetBottomLeftCorner(), GetTopRightCorner(), GetBottomRightCorner());
		}

		private float GetMaxXPosition ()
		{
			return CentralPoint.x + BoundariesSize.x;
		}

		private float GetMinXPosition ()
		{
			return CentralPoint.x - BoundariesSize.x;
		}

		private float GetMaxYPosition ()
		{
			return CentralPoint.y + BoundariesSize.y;
		}

		private float GetMinYPosition ()
		{
			return CentralPoint.y - BoundariesSize.y;
		}

		private Vector3 GetTopLeftCorner ()
		{
			return CentralPoint + new Vector3(-1.0f * BoundariesSize.x, BoundariesSize.y, 0.0f);
		}

		private Vector3 GetBottomLeftCorner ()
		{
			return CentralPoint + new Vector3(-1.0f * BoundariesSize.x, -1.0f * BoundariesSize.y, 0.0f);
		}

		private Vector3 GetTopRightCorner ()
		{
			return CentralPoint + new Vector3(BoundariesSize.x, BoundariesSize.y, 0.0f);
		}

		private Vector3 GetBottomRightCorner ()
		{
			return CentralPoint + new Vector3(BoundariesSize.x, -1.0f * BoundariesSize.y, 0.0f);
		}

		private void OnDrawGizmos ()
		{
#if UNITY_EDITOR
			DrawBoundaries();
#endif
		}

		private void DrawBoundaries ()
		{
			(Vector3 topLeftCorner, Vector3 bottomLeftCorner, Vector3 topRightCorner, Vector3 bottomRightCorner) =
				Application.isPlaying
					? SceneBoundariesSO.GetBoundariesCorners()
					: (GetTopLeftCorner(), GetBottomLeftCorner(), GetTopRightCorner(), GetBottomRightCorner());

			Gizmos.color = VisualizationColor;
			Gizmos.DrawLine(topLeftCorner, bottomLeftCorner);
			Gizmos.DrawLine(bottomLeftCorner, bottomRightCorner);
			Gizmos.DrawLine(bottomRightCorner, topRightCorner);
			Gizmos.DrawLine(topRightCorner, topLeftCorner);
		}
	}
}