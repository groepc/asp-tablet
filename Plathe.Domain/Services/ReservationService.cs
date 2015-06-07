using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using System;
using CustomExtensions;
using System.Reflection;

namespace Plathe.Domain.Services
{
    public class ReservationService : IReservationService
    {

        private IReservationRepository repository;

        public ReservationService(IReservationRepository reservationRepository)
        {

            // todo: make use of repository (but doesn't have Add method..)
            this.repository = reservationRepository;

        }

        public Reservation createReservation()
        {

            // create reservation
            var uniqueCode = "";
            uniqueCode = uniqueCode.createRandomString();

            Reservation reservation = new Reservation
            {
                UniqueCode = uniqueCode,
                CreateOn = DateTime.Now,
                PriceTotal = (decimal)0.00,
                Payed = false,
                PayedOn = DateTime.Now
            };

            // save reservation to DB
            // this will automatically add reservationId to the object

            return this.repository.saveReservation(reservation);

        }
    }
}
