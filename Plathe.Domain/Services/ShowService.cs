using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Services
{
    public class ShowService : IShowService
    {

        private IShowRepository repository;

        public ShowService(IShowRepository showRepository)
        {
            this.repository = showRepository;

        }

        public IEnumerable<Show> getAllShows()
        {
            return this.repository.Shows;
        }

        public IEnumerable<Show> getShowsThisWeek()
        {

            DateTime tomorrow = DateTime.Today.AddDays(1);

            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextThursday = tomorrow.AddDays(daysUntilThursday);

            IEnumerable<Show> shows = repository.Shows
                                                    .Where(s => s.StartingTime >= DateTime.Today)
                                                    .Where(s => s.StartingTime <= nextThursday);
            return shows;
        }

        public Show getShowById(int id)
        {
            return repository.Shows.FirstOrDefault(model => model.MovieID == id);
        }

        public IEnumerable<Show> getShowsByMovieId(int id)
        {
            return repository.Shows.Where(model => model.MovieID == id);
        }
    }
}
