using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Reservations { get; }

        Reservation SaveReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        int GetReservationIdByReservationCode(string code);
        Reservation UpdateReservation(Reservation reservation);
    }
}
