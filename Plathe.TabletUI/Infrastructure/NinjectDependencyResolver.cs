using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.TabletUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IMovieRepository>().To<EFMovieRepository>();
            kernel.Bind<IShowRepository>().To<EFShowRepository>();
        }
    }
}