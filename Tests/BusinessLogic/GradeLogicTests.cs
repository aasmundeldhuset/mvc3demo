using System;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic;
using Domain;
using Domain.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Tests.BusinessLogic
{
    public class GradeLogicTests
    {
        [Test]
        public void GradeArticle_ShouldCreateANewGrade_WhenTheUserHasNotGradedTheArticleBefore()
        {
            var article = new Article {Id = 20};
            var currentUser = new User {UserName = "asmunde"};
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(r => r.Get<Article>(20)).Returns(article);
            mockRepo.Setup(r => r.GetWhere<User>(It.IsAny<Expression<Func<User, bool>>>())).Returns(new[]{currentUser}.AsQueryable());
            var logic = new GradeLogic(mockRepo.Object);

            logic.GradeArticle(20, "asmunde", 4);

            Assert.That(article.Grades.Count, Is.EqualTo(1));
            Assert.That(currentUser.Grades.Count, Is.EqualTo(1));
            var grade = article.Grades.Single();
            Assert.That(grade, Is.SameAs(currentUser.Grades.Single()));
            Assert.That(grade.GradeValue, Is.EqualTo(4));
            mockRepo.Verify(r => r.SaveChanges());
        }
    }
}
