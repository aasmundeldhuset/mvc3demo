using System.Data;
using Migrator.Framework;

namespace Migrations.Migrations
{
    [Migration(002)]
    public class M002_AddingGradeModel : Migration
    {
        private const string
            Grade = "Grade",
            Article = "Article",
            User = "User",
            aspnet_Users = "aspnet_Users",
            Id = "Id",
            ArticleId = Article + Id,
            UserId = User + Id,
            GradeValue = "GradeValue";

        public override void Up()
        {
            Database.AddTable(
                Grade,
                new Column(Id, DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column(ArticleId, DbType.Int32, ColumnProperty.ForeignKey | ColumnProperty.NotNull),
                new Column(UserId, DbType.Guid, ColumnProperty.ForeignKey | ColumnProperty.NotNull),
                new Column(GradeValue, DbType.Int32, ColumnProperty.NotNull));
            Database.AddVersionColumn(Grade);
            Database.AddForeignKey(Grade, UserId, aspnet_Users, UserId);
            Database.AddForeignKey(Grade, ArticleId, Article, Id);
        }

        public override void Down()
        {
            Database.RemoveTable(Grade);
        }
    }
}
