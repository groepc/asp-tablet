﻿using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plathe.Domain.Concrete
{
    public class EfReservationRepository : IReservationRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Reservation> Reservations
        {
            get { return context.Reservations; }
        }

        public int GetReservationIdByReservationCode(string code)
        {
            return context.Reservations
                .Where(r => r.UniqueCode == code)
                .Select(r => r.ReservationId)
                .FirstOrDefault();
        }

        public Reservation GetReservationById(int id)
        {
            return context.Reservations.Find(id);
        }

        public Reservation SaveReservation(Reservation reservation) {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            context.SaveChanges();
            return reservation;
        }

    }
}