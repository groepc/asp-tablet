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

        private readonly IShowRepository _repository;

        public ShowService(IShowRepository showRepository)
        {
            _repository = showRepository;

        }

        public int SaveShow(int? showId, int movieId, int roomId, string subtitle, DateTime startingTime, bool threeDimensional)
        {

            if (startingTime.Date < DateTime.Now.Date)
            {
                return 1;
            }

            Show show = new Show
            {
                MovieId = movieId,
                RoomId = roomId,
                Subtitle = subtitle,
                StartingTime = startingTime,
                ThreeDimensional = threeDimensional
            };

            if (showId != null)
            {
                show.ShowId = Convert.ToInt32(showId);
                _repository.UpdateShow(show);
            }
            else
            {
                _repository.AddShow(show);
            }
            return 0;
        }

        public void RemoveShowById(int id)
        {
            _repository.RemoveShowById(id);
        }



        public IEnumerable<Show> GetAllShows()
        {
            return _repository.Shows;
        }

        public IEnumerable<Show> GetShowsByDate(DateTime date)
        {
            return _repository.Shows.Where(s => s.StartingTime.Date == date);
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

        public Show GetShowByMovieId(int id)
        {
            return _repository.Shows.FirstOrDefault(model => model.MovieId == id);
        }

        public IEnumerable<Show> GetShowsByMovieId(int id)
        {
            return _repository.Shows
                                .Where(model => model.MovieId == id)
                                .OrderBy(s => s.StartingTime);
        }
    }
}
