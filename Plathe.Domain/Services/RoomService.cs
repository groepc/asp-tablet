using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository roomRepository)
        {
            _repository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _repository.Rooms;
        }
    }
}
