﻿using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using System;
using CustomExtensions;
using Plathe.Domain.Extensions;
using System.Collections.Generic;

namespace Plathe.Domain.Services
{
    public class TicketService : ITicketService
    {

        private ITicketRepository repository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.repository = ticketRepository;
        }

        public void createTickets(List<Int32> ChosenSeat, int reservationID, Show show, bool secretMovie, int adults, int adultsPlus, int children, int Students, int popcorn)
        {
            var i = 0;
            while (adults > 0)
            {
                this.createTicket(reservationID, ChosenSeat[i], "adults", show, secretMovie);
                adults--;
                i++;
            }

            while (adultsPlus > 0)
            {
                this.createTicket(reservationID, ChosenSeat[i], "adultsplus", show, secretMovie);
                adultsPlus--;
                i++;
            }

            while (children > 0)
            {
                this.createTicket(reservationID, ChosenSeat[i], "children", show, secretMovie);
                children--;
                i++;
            }

            while (Students > 0)
            {
                this.createTicket(reservationID, ChosenSeat[i], "students", show, secretMovie);
                Students--;
                i++;
            }

            while (popcorn > 0)
            {
                this.createTicket(reservationID, ChosenSeat[i], "popcorn", show, secretMovie);
                popcorn--;
                i++;
            }

        }


        public Ticket createTicket(int reservationID, int seatID, string type, Show show, bool secretMovie = false)
        {

            // create reservation
            var uniqueCode = "";
            uniqueCode = uniqueCode.createRandomString();

            Ticket ticket = new Ticket
            {
                ShowID = show.ShowID,
                ReservationID = reservationID,
                SeatID = seatID,
                UniqueCode = uniqueCode,
                Price = new CalculatePrice().getTicketPricePrice(type, show, secretMovie),
                Options = "options",
                Type = type,
                PopcornTime = (type == "popcorn") ? true : false
            };

            // save reservation to DB
            // this will automatically add reservationId to the object

            return this.repository.saveTicket(ticket);

        }

    }
}