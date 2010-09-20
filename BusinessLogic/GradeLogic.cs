using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Domain.Repository;

namespace BusinessLogic
{
    public class GradeLogic
    {
        private readonly IRepository _repo;

        public GradeLogic(IRepository repo)
        {
            _repo = repo;
        }

        public void GradeArticle(int articleId, string currentUserName, int gradeValue)
        {
            var article = _repo.Get<Article>(articleId);
            var user = _repo.GetWhere<User>(u => u.UserName == currentUserName).Single();
            var oldGrade = article.Grades.SingleOrDefault(g => g.User == user);
            if (oldGrade == null)
                new Grade {Article = article, User = user, GradeValue = gradeValue};
            else
                oldGrade.GradeValue = gradeValue;
            _repo.SaveChanges();
        }
    }
}
