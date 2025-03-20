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
		private Vector2 CentralPoint { get; set; }
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

		private Vector2 GetTopLeftCorner ()
		{
			return CentralPoint + new Vector2(-1.0f * BoundariesSize.x, BoundariesSize.y);
		}

		private Vector2 GetBottomLeftCorner ()
		{
			return CentralPoint + new Vector2(-1.0f * BoundariesSize.x, -1.0f * BoundariesSize.y);
		}

		private Vector2 GetTopRightCorner ()
		{
			return CentralPoint + new Vector2(BoundariesSize.x, BoundariesSize.y);
		}

		private Vector2 GetBottomRightCorner ()
		{
			return CentralPoint + new Vector2(BoundariesSize.x, -1.0f * BoundariesSize.y);
		}

		private void OnDrawGizmos ()
		{
#if UNITY_EDITOR
			DrawBoundaries();
#endif
		}

		private void DrawBoundaries ()
		{
			(Vector2 topLeftCorner, Vector2 bottomLeftCorner, Vector2 topRightCorner, Vector2 bottomRightCorner) =
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