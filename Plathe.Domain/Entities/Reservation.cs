using System;
using System.Collections.Generic;
using System.Linq;

namespace Plathe.Domain.Entities
{

    public class ReservationTickets
    {
        public int SaveReservationWithTickets(int showId, int? adults, int? adultsplus, int? childs, int? popcorn, int? vip)
        {
            Reservation reservation = new Reservation
            {
                UniqueCode = RandomChars(8),
                CreateOn = DateTime.Now,
            };

            var reservationId = reservation.ReservationId;

            return reservation.ReservationId;
        }

        public string RandomChars(int stringLenght)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, stringLenght)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string UniqueCode { get; set; }
        public Decimal PriceTotal { get; set; }
        public DateTime CreateOn { get; set; }
        public Boolean Payed { get; set; }
        public DateTime PayedOn { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
