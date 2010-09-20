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
        private IRepository _repo;

        public GradeLogic(IRepository repo)
        {
            _repo = repo;
        }


        public void GradeArticle(int articleId, string currentUserName, int gradeValue)
        {
            var article = _repo.Get<Article>(articleId);
            var user = _repo.GetWhere<User>(u => u.UserName == currentUserName).Single();
            new Grade {Article = article, User = user, GradeValue = gradeValue};
            _repo.SaveChanges();
        }
    }
}
