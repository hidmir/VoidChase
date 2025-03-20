namespace VoidChase.Utilities
{
	public static class PrefsKeysGenerator
	{
		public static string GetLevelScoreKey (string levelName)
		{
			return $"BestScore_{levelName}";
		}
	}
}