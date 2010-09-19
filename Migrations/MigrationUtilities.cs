using System.Collections.Generic;
using Migrator.Framework;

namespace Migrations
{
    public static class MigrationUtilities
    {
        public static void AddForeignKey(this ITransformationProvider migration, string foreignTable, string primaryTable)
        {
            migration.AddForeignKey(migration.ForeignKeyName(foreignTable, primaryTable),
                                    foreignTable,
                                    primaryTable + "Id",
                                    primaryTable,
                                    "Id");
        }

        public static string ForeignKeyName(this ITransformationProvider migration, string foreignTable, string primaryTable)
        {
            return string.Format("FK__{0}__{1}Id__{1}__Id", foreignTable, primaryTable);
        }

        public static string ForeignKeyName(this ITransformationProvider migration, string foreignKeyTable, string primaryTable, string foreignColumnName)
        {
            return string.Format("FK__{0}__{2}__{1}__Id", foreignKeyTable, primaryTable, foreignColumnName);
        }

        public static void DropForeignKey(this ITransformationProvider migration, string foreignTable, string primaryTable)
        {
            migration.RemoveForeignKey(foreignTable, string.Format("FK__{0}__{1}Id__{1}__Id", foreignTable, primaryTable));
        }

        public static void AddVersionColumn(this ITransformationProvider migration, string table)
        {
            migration.ExecuteNonQuery(string.Format("ALTER TABLE [{0}] ADD [Version] [timestamp] NOT NULL", table));
        }

        public static void AddUniqueConstr(this ITransformationProvider migration, string table, params string[] columns)
        {
            string name = migration.UniqueConstraintName(table, columns);
            migration.AddUniqueConstraint(name, table, columns);
        }

        public static void DropUniqueConstraint(this ITransformationProvider migration, string table, params string[] columns)
        {
            string name = migration.UniqueConstraintName(table, columns);
            migration.RemoveConstraint(table, name);
        }

        public static string UniqueConstraintName(this ITransformationProvider migration, string table, params string[] columns)
        {
            return "UQ__" + table + "__" + string.Join("__", columns);
        }

        /// <summary>
        /// Calls Insert() with the given parameters and returns the id of the newly inserted row.
        /// </summary>
        public static int InsertAndGetId(this ITransformationProvider migration, string table, string[] columns, params string[] values)
        {
            migration.Insert(table, columns, values);
            return migration.GetLastInsertedId();
        }

        /// <summary>
        /// Calls Insert() repeatedly with the given parameters and returns the id of the newly inserted rows.
        /// </summary>
        public static IList<int> InsertAndGetIds(this ITransformationProvider migration, string table, string[] columns, params string[][] rows)
        {
            var ids = new List<int>();
            foreach (var row in rows)
            {
                migration.Insert(table, columns, row);
                ids.Add(migration.GetLastInsertedId());
            }
            return ids;
        }

        public static int GetLastInsertedId(this ITransformationProvider migration)
        {
            var query = "SELECT @@IDENTITY";
            var result = migration.ExecuteScalar(query);
            return int.Parse(result.ToString());
        }

        public static int DeleteAllRowsFromTable(this ITransformationProvider migration, string tableName)
        {
            return migration.ExecuteNonQuery(string.Format("DELETE FROM {0}", tableName));
        }
    }
}
