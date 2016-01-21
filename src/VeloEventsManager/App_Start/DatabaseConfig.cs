namespace VeloEventsManager.App_Start
{
	using System.Data.Entity;

	using VeloEventsManager.Data;
	using VeloEventsManager.Data.Migrations;

	public static class DatabaseConfig
	{
		public static void Initialize()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<VeloEventsManagerDbContext, Configuration>());
			VeloEventsManagerDbContext.Create().Database.Initialize(true);
		}
	}
}