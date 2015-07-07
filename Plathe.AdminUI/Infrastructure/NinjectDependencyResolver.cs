using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Services;

namespace Plathe.AdminUI.Infrastructure
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
            // repositorys
            kernel.Bind<IMovieRepository>().To<EfMovieRepository>();
            kernel.Bind<IGenreRepository>().To<EfGenreRepository>();
            // services
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IGenreService>().To<GenreService>();
        }
    }
}