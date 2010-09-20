using System.Security.Principal;
using System.Web.Mvc;
using BusinessLogic;
using Domain;
using Domain.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using WebApp.Controllers;
using WebApp.ViewModels;

namespace Tests.Controllers
{
    public class GradeControllerTests
    {
        [Test]
        public void Grade_ShouldCallBusinessLogicMethodWithCurrentUserAndRedirectToShowArticle()
        {
            var mockLogic = new Mock<GradeLogic>();
            var mockUser = new Mock<IPrincipal>();
            mockUser.SetupGet(u => u.Identity.Name).Returns("asmunde");
            var controller = new GradeController(mockLogic.Object);
            controller.MockUser = mockUser.Object;

            var result = (RedirectToRouteResult) controller.GradeArticle(20, 4);

            mockLogic.Verify(logic => logic.GradeArticle(20, "asmunde", 4));
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Article"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Show"));
            Assert.That(result.RouteValues["id"], Is.EqualTo(20));
        }

        [Test]
        public void ArticleDetailsModel_ShouldShowGradeAverageWithTwoDecimals()
        {
            var article = new Article();
            article.Author = new User {UserName = "asmunde"};
            article.Body = "";

            var model = new ArticleDetailsModel(article, "asmunde");

            Assert.That(model.GradeAverage, Is.EqualTo("3.00"));
        }

        [Test]
        public void ArticleDetailsModel_ShouldShowGradeGivenByCurrentUser()
        {
            var article = new Article();
            article.Author = new User {UserName = "asmunde"};
            article.Grades.Add(new Grade {User = article.Author, GradeValue = 4});
            article.Body = "";

            var model = new ArticleDetailsModel(article, "asmunde");

            Assert.That(model.GradeValue, Is.EqualTo(4));
        }
    }
}
