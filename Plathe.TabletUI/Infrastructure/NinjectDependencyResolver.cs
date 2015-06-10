using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;
using Plathe.Domain.Services;

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
            // repositorys
            kernel.Bind<IMovieRepository>().To<EFMovieRepository>();
            kernel.Bind<IShowRepository>().To<EFShowRepository>();
            kernel.Bind<IReservationRepository>().To<EFReservationRepository>();

            // services
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IShowService>().To<ShowService>();
            kernel.Bind<IReservationService>().To<ReservationService>();
        }
    }
}