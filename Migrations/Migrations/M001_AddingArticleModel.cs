using System.Data;
using Migrator.Framework;

namespace Migrations.Migrations
{
    [Migration(001)]
    public class M001_AddingArticleModel : Migration
    {
        private const string Article = "Article", AuthorId = "AuthorId";

        public override void Up()
        {
            const int titleLength = 255, summaryLength = 4095, bodyLength = 1048575;

            Database.AddTable(
                Article, 
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column(AuthorId, DbType.Guid, ColumnProperty.ForeignKey | ColumnProperty.NotNull),
                new Column("Title", DbType.String, titleLength, ColumnProperty.NotNull),
                new Column("Summary", DbType.String, summaryLength, ColumnProperty.NotNull),
                new Column("Body", DbType.String, bodyLength, ColumnProperty.NotNull));
            Database.AddVersionColumn(Article);
            Database.AddForeignKey(Article, AuthorId, "aspnet_Users", "UserId");
        }

        public override void Down()
        {
            Database.RemoveTable(Article);
        }
    }
}
