using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.GameManagement
{
	public class SceneBoundariesController : MonoBehaviour
	{
		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private Vector3 CentralPoint { get; set; }
		[field: SerializeField]
		private Vector2 BoundariesSize { get; set; }

		[field: Header(InspectorNames.VISUALIZATION_NAME)]
		[field: SerializeField]
		private Color VisualizationColor { get; set; } = Color.yellow;

		public (float maxX, float minX, float maxY, float minY) GetMaxMinPositions ()
		{
			return (GetMaxXPosition(), GetMinXPosition(), GetMaxYPosition(), GetMinYPosition());
		}
		
		public (Vector3 maxX, Vector3 minX, Vector3 maxY, Vector3 minY) GetBoundariesCorners ()
		{
			return (GetTopLeftCorner(), GetBottomLeftCorner(), GetTopRightCorner(), GetBottomRightCorner());
		}

		public float GetMaxXPosition ()
		{
			return CentralPoint.x + BoundariesSize.x;
		}

		public float GetMinXPosition ()
		{
			return CentralPoint.x - BoundariesSize.x;
		}

		public float GetMaxYPosition ()
		{
			return CentralPoint.y + BoundariesSize.y;
		}

		public float GetMinYPosition ()
		{
			return CentralPoint.y - BoundariesSize.y;
		}

		public Vector3 GetTopLeftCorner ()
		{
			return CentralPoint + new Vector3(-1.0f * BoundariesSize.x, BoundariesSize.y, 0.0f);
		}

		public Vector3 GetBottomLeftCorner ()
		{
			return CentralPoint + new Vector3(-1.0f * BoundariesSize.x, -1.0f * BoundariesSize.y, 0.0f);;
		}

		public Vector3 GetTopRightCorner ()
		{
			return CentralPoint + new Vector3(BoundariesSize.x, BoundariesSize.y, 0.0f);
		}

		public Vector3 GetBottomRightCorner ()
		{
			return CentralPoint + new Vector3(BoundariesSize.x, -1.0f * BoundariesSize.y, 0.0f);
		}

		protected virtual void OnDrawGizmos ()
		{
			DrawBoundaries();
		}

		private void DrawBoundaries ()
		{
			(Vector3 topLeftCorner, Vector3 bottomLeftCorner, Vector3 topRightCorner, Vector3 bottomRightCorner) = GetBoundariesCorners();

			Gizmos.color = VisualizationColor;
			Gizmos.DrawLine(topLeftCorner, bottomLeftCorner);
			Gizmos.DrawLine(bottomLeftCorner, bottomRightCorner);
			Gizmos.DrawLine(bottomRightCorner, topRightCorner);
			Gizmos.DrawLine(topRightCorner, topLeftCorner);
		}
	}
}