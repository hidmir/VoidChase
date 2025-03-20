using UnityEngine;
using VoidChase.Utilities;
using VoidChase.Utilities.Attributes;

namespace VoidChase.Environment.SceneBoundaries
{
	[CreateAssetMenu(fileName = nameof(SceneBoundariesSO), menuName = MenuNames.ENVIRONMENT_PATH + nameof(SceneBoundariesSO))]
	public class SceneBoundariesSO : ScriptableObject
	{
		[field: Header("Position Limits")]
		[field: SerializeField, ReadOnly]
		public float MaxX { get; private set; }
		[field: SerializeField, ReadOnly]
		public float MinX { get; private set; }
		[field: SerializeField, ReadOnly]
		public float MaxY { get; private set; }
		[field: SerializeField, ReadOnly]
		public float MinY { get; private set; }

		[field: Header("Corners")]
		[field: SerializeField, ReadOnly]
		public Vector2 TopLeftCorner { get; private set; }
		[field: SerializeField, ReadOnly]
		public Vector2 BottomLeftCorner { get; private set; }
		[field: SerializeField, ReadOnly]
		public Vector2 TopRightCorner { get; private set; }
		[field: SerializeField, ReadOnly]
		public Vector2 BottomRightCorner { get; private set; }

		public void SetPositionLimits (float maxX, float minX, float maxY, float minY)
		{
			MaxX = maxX;
			MinX = minX;
			MaxY = maxY;
			MinY = minY;
		}

		public void SetBoundariesCorners (Vector2 maxX, Vector2 minX, Vector2 maxY, Vector2 minY)
		{
			TopLeftCorner = maxX;
			BottomLeftCorner = minX;
			TopRightCorner = maxY;
			BottomRightCorner = minY;
		}

		public (float maxX, float minX, float maxY, float minY) GetMaxMinPositions ()
		{
			return (MaxX, MinX, MaxY, MinY);
		}

		public (Vector2 maxX, Vector2 minX, Vector2 maxY, Vector2 minY) GetBoundariesCorners ()
		{
			return (TopLeftCorner, BottomLeftCorner, TopRightCorner, BottomRightCorner);
		}
	}
}