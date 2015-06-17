using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfReservationRepository : IReservationRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<Reservation> Reservations
        {
            get { return _context.Reservations; }
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.Find(id);
        }

        public Reservation SaveReservation(Reservation reservation) {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _context.SaveChanges();
            return reservation;
        }

    }
}