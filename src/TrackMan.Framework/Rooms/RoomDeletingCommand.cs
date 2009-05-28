using TrackMan.Framework.Assets.Repositories.UOWAssetRepository;

namespace TrackMan.Framework.Rooms
{
    public class RoomDeletingCommand : IDeletingCommand
    {
        private readonly Room roomBeingDeleted;
        private readonly IAssetRepository repository;

        public RoomDeletingCommand(Room roomBeingDeleted, IAssetRepository repository)
        {
            this.roomBeingDeleted = roomBeingDeleted;
            this.repository = repository;
        }

        public void Deleting()
        {
            var assetsInRoom = repository.GetByRoomId(roomBeingDeleted.Id);
            if(assetsInRoom.Length > 0)
            {
                throw new DeletingCommandException("You cannot delete a room that is being used by one or more assets.");
            }
        }
    }
}