using UnityEngine;

namespace VoidChase.Utilities
{
	public static class GizmosExtensions
	{
		public static void DrawWireCapsule (Vector3 point1, Vector3 point2, float radius)
		{
			Gizmos.DrawWireSphere(point1, radius);
			Gizmos.DrawWireSphere(point2, radius);

			if (!Mathf.Approximately(point1.x, point2.x))
			{
				Gizmos.DrawLine(point1 + new Vector3(0.0f, radius, 0.0f), point2 + new Vector3(0.0f, radius, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, -radius, 0.0f), point2 + new Vector3(0.0f, -radius, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, 0.0f, radius), point2 + new Vector3(0.0f, 0.0f, radius));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, 0.0f, -radius), point2 + new Vector3(0.0f, 0.0f, -radius));
			}
			else if (!Mathf.Approximately(point1.y, point2.y))
			{
				Gizmos.DrawLine(point1 + new Vector3(radius, 0.0f, 0.0f), point2 + new Vector3(radius, 0.0f, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(-radius, 0.0f, 0.0f), point2 + new Vector3(-radius, 0.0f, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, 0.0f, radius), point2 + new Vector3(0.0f, 0.0f, radius));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, 0.0f, -radius), point2 + new Vector3(0.0f, 0.0f, -radius));
			}
			else if (!Mathf.Approximately(point1.z, point2.z))
			{
				Gizmos.DrawLine(point1 + new Vector3(radius, 0.0f, 0.0f), point2 + new Vector3(radius, 0.0f, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(-radius, 0.0f, 0.0f), point2 + new Vector3(-radius, 0.0f, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, radius, 0.0f), point2 + new Vector3(0.0f, radius, 0.0f));
				Gizmos.DrawLine(point1 + new Vector3(0.0f, -radius, 0.0f), point2 + new Vector3(0.0f, -radius, 0.0f));
			}
		}
	}
}