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
        Reservation createReservation();

        Reservation getReservationById(int id);
    }
}
