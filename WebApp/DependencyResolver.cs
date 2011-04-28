using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogic;
using Domain;
using Ninject;
using Ninject.Parameters;

namespace WebApp
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }
    }

    public class NinjectContainerSetup
    {
        public static void SetUp()
        {
            var kernel = new StandardKernel(new RepoModule(), new LogicModule());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
