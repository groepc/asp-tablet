using Moq;
using Ninject;
using Plathe.Domain.Abstract;
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
            kernel.Bind<IGenreRepository>().To<EfGenreRepository>();
            kernel.Bind<IMovieRepository>().To<EfMovieRepository>();
            kernel.Bind<IReservationRepository>().To<EfReservationRepository>();
            kernel.Bind<IRoomRepository>().To<EfRoomRepository>();
            kernel.Bind<IRowRepository>().To<EfRowRepository>();
            kernel.Bind<ISeatRepository>().To<EfSeatRepository>();
            kernel.Bind<IShowRepository>().To<EfShowRepository>();
            kernel.Bind<ITicketRepository>().To<EfTicketRepository>();

            // services
            kernel.Bind<IReservationService>().To<ReservationService>();
            kernel.Bind<ITicketService>().To<TicketService>();
            kernel.Bind<IShowService>().To<ShowService>();
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IGenreService>().To<GenreService>();
        }
    }
}