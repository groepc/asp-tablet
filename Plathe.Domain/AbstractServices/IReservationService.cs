using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.AbstractServices
{
    public interface IReservationService
    {
        Reservation CreateReservation();

        Reservation GetReservationById(int id);

        Reservation UpdateReservation(int reservationId, decimal price);

        int GetReservationIdByReservationCode(string code);
    }
}
