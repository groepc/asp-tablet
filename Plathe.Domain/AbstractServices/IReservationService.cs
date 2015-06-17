using Plathe.Domain.Entities;

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
