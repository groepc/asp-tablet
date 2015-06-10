using Moq;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using Plathe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Services;

namespace Plathe.WebUI.Infrastructure
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
            // repositories
            kernel.Bind<IGenreRepository>().To<EFGenreRepository>();
            kernel.Bind<IMovieRepository>().To<EFMovieRepository>();
            kernel.Bind<IReservationRepository>().To<EFReservationRepository>();
            kernel.Bind<IRoomRepository>().To<EFRoomRepository>();
            kernel.Bind<IRowRepository>().To<EFRowRepository>();
            kernel.Bind<ISeatRepository>().To<EFSeatRepository>();
            kernel.Bind<IShowRepository>().To<EFShowRepository>();
            kernel.Bind<ITicketRepository>().To<EFTicketRepository>();

            // services
            kernel.Bind<IReservationService>().To<ReservationService>();
            kernel.Bind<ITicketService>().To<TicketService>();
            kernel.Bind<IShowService>().To<ShowService>();
            kernel.Bind<IMovieService>().To<MovieService>();
        }
    }
}