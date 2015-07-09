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
        private readonly IMovieRepository _movieRepository;

        public ShowService(IShowRepository showRepository, IMovieRepository movieRepository)
        {
            _repository = showRepository;
            _movieRepository = movieRepository;

        }

        public int SaveShow(int? showId, int movieId, int roomId, string subtitle, DateTime startingTime, bool threeDimensional)
        {

            const int cleanTime = 15;

            if (startingTime.Date < DateTime.Now.Date)
            {
                return 1;
            }

            var durationMovie = _movieRepository.FindMovieById(movieId).Duration;
            //add 15 minutes clean time to the duration
            var endtime = startingTime.AddMinutes(durationMovie + cleanTime);

            //endtime is duration + 15 minutes clean time
            var totalShows = (from s in _repository.Shows
                              join m in _movieRepository.Movies on s.MovieId equals m.MovieId
                              where s.RoomId == roomId && 
                             startingTime <= s.StartingTime.AddMinutes(m.Duration + cleanTime) &&
                              s.StartingTime <= endtime
                              
                              //((startingTime >= s.StartingTime && s.StartingTime.AddMinutes(m.Duration + cleanTime) < startingTime) ||
                             //startingTime <= s.StartingTime.AddMinutes(m.Duration + cleanTime)) || (endtime > s.StartingTime && s.StartingTime < endtime)
                              select s.ShowId).Count();

            if (totalShows > 0)
            {
                return 2;
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
