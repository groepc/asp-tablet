using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Services;
using Plathe.WebUI.Infrastructure.Abstract;
using Plathe.WebUI.Infrastructure.Concrete;

namespace Plathe.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // repositories
            _kernel.Bind<IGenreRepository>().To<EfGenreRepository>();
            _kernel.Bind<IMovieRepository>().To<EfMovieRepository>();
            _kernel.Bind<IReservationRepository>().To<EfReservationRepository>();
            _kernel.Bind<IRoomRepository>().To<EfRoomRepository>();
            _kernel.Bind<IRowRepository>().To<EfRowRepository>();
            _kernel.Bind<ISeatRepository>().To<EfSeatRepository>();
            _kernel.Bind<IShowRepository>().To<EfShowRepository>();
            _kernel.Bind<ITicketRepository>().To<EfTicketRepository>();
            _kernel.Bind<ILostItemRepository>().To<EfLostItemRepository>();

            // services
            _kernel.Bind<IReservationService>().To<ReservationService>();
            _kernel.Bind<ITicketService>().To<TicketService>();
            _kernel.Bind<IShowService>().To<ShowService>();
            _kernel.Bind<IMovieService>().To<MovieService>();
            _kernel.Bind<IGenreService>().To<GenreService>();

            //authentication
            _kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}