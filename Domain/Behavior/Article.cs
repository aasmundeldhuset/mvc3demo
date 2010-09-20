using System.Linq;
using Commons;

namespace Domain
{
    public partial class Article
    {
        public decimal GetGradeAverage()
        {
            var userGradesAndInitialGrade = Grades.Select(g => g.GradeValue).Concat(new[] {Constants.InitialGradeValue});
            decimal unroundedAverage = (decimal) userGradesAndInitialGrade.Average();
            return Utilities.RoundTowardsZeroToTwoDecimals(unroundedAverage);
        }
    }
}
