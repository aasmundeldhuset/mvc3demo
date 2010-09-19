using Migrator.Framework.Loggers;

namespace Migrations
{
    public class ExternallyCallableMigration
    {
        public static void MigrateToLastVersion(string provider, string connectionString)
        {
            Migrator.Migrator migrator = GetMigrator(provider, connectionString);
            migrator.MigrateToLastVersion();
        }

        public static void ResetDatabase(string provider, string connectionString)
        {
            Migrator.Migrator migrator = GetMigrator(provider, connectionString);
            migrator.MigrateTo(0);
            migrator.MigrateToLastVersion();
        }

        private static Migrator.Migrator GetMigrator(string provider, string connectionString)
        {
            var silentLogger = new Logger(false, new ILogWriter[0]);
            return new Migrator.Migrator(provider,
                                         connectionString,
                                         typeof(ExternallyCallableMigration).Assembly,
                                         false,
                                         silentLogger);
        }
    }
}