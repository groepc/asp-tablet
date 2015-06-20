using System;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.Domain.Extensions;

namespace Plathe.Domain.Services
{
    public class ReservationService : IReservationService
    {

        private IReservationRepository _repository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _repository = reservationRepository;

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

            return _repository.SaveReservation(reservation);

        }

        public Reservation GetReservationById(int id)
        {
            return _repository.GetReservationById(id);
        }

        public int GetReservationIdByReservationCode(string code)
        {
            return _repository.GetReservationIdByReservationCode(code);
        }

        public Reservation UpdateReservation(int reservationId, decimal price)
        {

            Reservation reservation = GetReservationById(reservationId);
            reservation.PriceTotal = price;
            return _repository.UpdateReservation(reservation);
        }
    }
}
