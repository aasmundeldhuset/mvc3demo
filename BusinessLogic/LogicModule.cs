using Ninject.Modules;

namespace BusinessLogic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GradeLogic>().To<GradeLogic>().InRequestScope();
        }
    }
}