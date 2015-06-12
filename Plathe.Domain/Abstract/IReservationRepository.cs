using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Abstract
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Reservations { get; }

        Reservation SaveReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        Reservation UpdateReservation(Reservation reservation);
    }
}
