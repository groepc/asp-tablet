using Plathe.Domain.Entities;

namespace Plathe.Domain.AbstractServices
{
    public interface IReservationService
    {
        Reservation CreateReservation();

        Reservation GetReservationById(int id);
        int GetReservationIdByReservationCode(string code);

        Reservation UpdateReservation(int reservationId, decimal price);
    }
}
