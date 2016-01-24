namespace VeloEventsManager.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.Delete("VeloEventsManager");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VeloEventsManagerDbContext, Configuration>());
            VeloEventsManagerDbContext.Create().Database.Initialize(true);
        }
    }
}