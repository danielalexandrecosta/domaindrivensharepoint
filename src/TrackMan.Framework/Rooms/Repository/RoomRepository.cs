using System.Collections.Generic;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Rooms.Repository
{
    public class RoomRepository
    {
        private readonly IListService<Room> listService;

        public RoomRepository(IListService<Room> listService)
        {
            this.listService = listService;
        }

        public Room[] GetRooms()
        {
            var roomItems = listService.GetAll();
            var rooms = new List<Room>();
            foreach(var roomItem in roomItems)
            {
                rooms.Add(roomItem.CreateEntity());
            }
            return rooms.ToArray();
        }
    }
}