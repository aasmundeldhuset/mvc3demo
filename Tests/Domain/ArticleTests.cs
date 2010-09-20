using Domain;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Tests.Domain
{
    public class ArticleTests
    {
        [Test]
        public void GetGradeAverage_ShouldYield3_WhenThereAreNoGrades()
        {
            var article = new Article();
            decimal grade = article.GetGradeAverage();
            Assert.That(grade, Is.EqualTo(3m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverage_WhenThereIsOneBadGrade()
        {
            var article = new Article();
            AddGrades(article, 1);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(2m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverage_WhenThereIsOneNeutralGrade()
        {
            var article = new Article();
            AddGrades(article, 3);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(3m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverage_WhenThereIsOneGoodGrade()
        {
            var article = new Article();
            AddGrades(article, 5);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(4m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverage_WhenThereAreManyGrades()
        {
            var article = new Article();
            AddGrades(article, 2, 5, 2, 3, 2, 1, 4, 5);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(3m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverageWithDecimals()
        {
            var article = new Article();
            AddGrades(article, 2);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(2.5m));
        }

        [Test]
        public void GetGradeAverage_ShouldYieldArithmeticAverageRoundedDownToTwoDecimals_WhenThereAreManyGrades()
        {
            var article = new Article();
            AddGrades(article, 4, 1);

            decimal grade = article.GetGradeAverage();

            Assert.That(grade, Is.EqualTo(2.66m));
        }

        private void AddGrades(Article article, params int[] gradeValues)
        {
            foreach (int gradeValue in gradeValues)
                article.Grades.Add(new Grade {GradeValue = gradeValue});
        }
    }
}
