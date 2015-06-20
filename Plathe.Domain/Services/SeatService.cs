using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Concrete;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class SeatService : ISeatService
    {
        private ISeatRepository _seatRepository;
        private IRowRepository _rowRepository;

        public SeatService(ISeatRepository seatRepository, IRowRepository rowRepository)
        {
            _seatRepository = seatRepository;
            _rowRepository = rowRepository;
        }

        public List<int> FindFreeSeats(Show show, int amount)
        {
            var room = show.Room.RoomId;
            var rowId = _rowRepository.Rows.First();
            List<int> list = new List<int>();

            var seats = _seatRepository.Seats
                .Where(model => model.RowId == rowId.RowId)
                .Take(amount);

            foreach (var seat in seats)
            {
                list.Add(seat.SeatId);
            }

            return list;
        }
    }
}
