using System;
using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class ShowService : IShowService
    {

        private IShowRepository _repository;

        public ShowService(IShowRepository showRepository)
        {
            _repository = showRepository;

        }

        public IEnumerable<Show> GetAllShows()
        {
            return _repository.Shows;
        }

        public IEnumerable<Show> GetShowsThisWeek()
        {

            DateTime tomorrow = DateTime.Today.AddDays(1);

            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextThursday = tomorrow.AddDays(daysUntilThursday);

            IEnumerable<Show> shows = _repository.Shows
                                                    .Where(s => s.StartingTime >= DateTime.Today)
                                                    .Where(s => s.StartingTime <= nextThursday)
                                                    .OrderBy(s => s.StartingTime);
            return shows;
        }

        public Show GetShowById(int id)
        {
            return _repository.Shows.FirstOrDefault(model => model.ShowId == id);
        }

        public IEnumerable<Show> GetShowsByMovieId(int id)
        {
            return _repository.Shows
                                .Where(model => model.MovieId == id)
                                .OrderBy(s => s.StartingTime);
        }
    }
}
