using System.Security.Principal;
using System.Web.Mvc;
using BusinessLogic;
using Domain.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using WebApp.Controllers;

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
            var controller = new GradeController(new Mock<IRepository>().Object, mockLogic.Object, mockUser.Object);

            var result = (RedirectToRouteResult) controller.GradeArticle(20, 4);

            mockLogic.Verify(logic => logic.GradeArticle(20, "asmunde", 4));
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Article"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Show"));
            Assert.That(result.RouteValues["id"], Is.EqualTo(20));
        }
    }
}
