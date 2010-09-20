using Domain.Repository;
using Ninject.Modules;

namespace Domain
{
    public class RepoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository.Repository>().InRequestScope();
        }
    }
}