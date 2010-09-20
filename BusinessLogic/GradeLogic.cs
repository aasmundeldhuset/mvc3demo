using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
