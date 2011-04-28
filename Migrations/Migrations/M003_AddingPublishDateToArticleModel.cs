using System.Data;
using Migrator.Framework;

namespace Migrations.Migrations
{
    [Migration(003)]
    public class M003_AddingPublishDateToArticleModel : Migration
    {
        private const string Article = "Article", PublishDate = "PublishDate";

        
        public override void Up()
        {
            Database.AddColumn(Article, PublishDate, DbType.DateTime);
        }

        public override void Down()
        {
            Database.RemoveColumn(Article, PublishDate);
        }
    }
}
