namespace VeloEventsManager.Common
{
	public static class Constants
	{
		private static string[] languages = new string[] { "None", "English", "Spanish", "German", "French", "Other" };
		private static string[] skills = { "None", "Mechanic", "Medic", "Orientation", "Other" };

		public static string[] Languages { get { return languages; } }
		public static string[] Skills { get { return skills; } }
	}
}
