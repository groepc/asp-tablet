using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.Domain.Extensions;

namespace Plathe.Domain.Services
{
    public class TicketService : ITicketService
    {

        private ITicketRepository _repository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _repository = ticketRepository;
        }

        public decimal CreateTickets(List<Int32> chosenSeat, int reservationId, Show show, bool secretMovie, int adults, int adultsPlus, int children, int students, int popcorn, int vip)
        {
            decimal totalPrice = 0.00M;

            var i = 0;
            while (adults > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "adults", show, secretMovie).Price;
                adults--;
                i++;
            }

            while (adultsPlus > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "adultsplus", show, secretMovie).Price;
                adultsPlus--;
                i++;
            }

            while (children > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "children", show, secretMovie).Price;
                children--;
                i++;
            }

            while (students > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "students", show, secretMovie).Price;
                students--;
                i++;
            }

            while (popcorn > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "popcorn", show, secretMovie).Price;
                popcorn--;
                i++;
            }

            while (vip > 0)
            {
                totalPrice += CreateTicket(reservationId, chosenSeat[i], "vip", show, secretMovie).Price;
                vip--;
                i++;
            }
            return totalPrice;
        }


        public Ticket CreateTicket(int reservationId, int seatId, string type, Show show, bool secretMovie = false)
        {

            // create reservation
            var uniqueCode = "";
            uniqueCode = uniqueCode.CreateRandomString();

            Ticket ticket = new Ticket
            {
                ShowId = show.ShowId,
                ReservationId = reservationId,
                SeatId = seatId,
                UniqueCode = uniqueCode,
                Price = new CalculatePrice().GetTicketPricePrice(type, show, secretMovie),
                Options = "options",
                Type = type,
                PopcornTime = type == "popcorn"
            };

            // save reservation to DB
            // this will automatically add reservationId to the object

            return _repository.SaveTicket(ticket);

        }

        public IEnumerable<Ticket> GetTicketsByReservationId(int id)
        {
            return _repository.GetTicketsByReservationId(id);
        }

        public Ticket GetTicketByUniqueCode(string code)
        {
            return _repository.Tickets.First(m => m.UniqueCode == code);
        }

    }
}
