using System.Data;
using Migrator.Framework;

namespace Migrations.Migrations
{
    [Migration(004)]
    public class M004_AddingEmailAddressToArticleModel : Migration
    {
        private const string Article = "Article", EmailAddress = "EmailAddress";

        
        public override void Up()
        {
            Database.AddColumn(Article, EmailAddress, DbType.String, 255, ColumnProperty.Null);
        }

        public override void Down()
        {
            Database.RemoveColumn(Article, EmailAddress);
        }
    }
}
