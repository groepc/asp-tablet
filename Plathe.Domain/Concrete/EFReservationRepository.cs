using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plathe.Domain.Concrete
{
    public class EFReservationRepository : IReservationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Reservation> Reservations
        {
            get { return context.Reservations; }
        }

        public Reservation saveReservation(Reservation reservation) {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return reservation;
        }

    }
}