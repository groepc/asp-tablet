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
            this.repository = reservationRepository;

        }

        public Reservation UpdateReservation (int reservationId, decimal price) {

            Reservation reservation = GetReservationById(reservationId);
            reservation.PriceTotal = price;
            return this.repository.UpdateReservation(reservation);
        }

        public Reservation CreateReservation()
        {

            // create reservation
            var uniqueCode = "";
            uniqueCode = uniqueCode.CreateRandomString();

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

            return this.repository.SaveReservation(reservation);

        }

        public Reservation GetReservationById(int id)
        {
            return this.repository.GetReservationById(id);
        }
    }
}
