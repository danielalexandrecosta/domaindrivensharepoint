using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository;
using TrackMan.Framework.Rooms;

namespace TrackMan.Framework.UnitTests.RoomTests
{
    [TestFixture]
    public class WhenInvokingRoomDeletingCommand
    {
        private Room room;
        private Mock<IAssetRepository> repositoryMock;
        private Asset asset;

        [SetUp]
        public void SetUp()
        {
            room = new Room(1, "Test Room");
            asset = new Asset("1234");
            repositoryMock = new Mock<IAssetRepository>();
        }

        [Test]
        [ExpectedException(typeof(DeletingCommandException))]
        public void ShouldThrowExceptionIfAssetIsAssignedToRoom()
        {
            repositoryMock.Setup(repo => repo.GetByRoomId(room.Id)).Returns(new[] { asset });
            new RoomDeletingCommand(room, repositoryMock.Object).Deleting();
        }

        [Test]
        public void ShouldSucceedIfNoAssetIsAssignedToRoom()
        {
            repositoryMock.Setup(repo => repo.GetByRoomId(room.Id)).Returns(new Asset[] { });
            new RoomDeletingCommand(room, repositoryMock.Object).Deleting();
        }
    }
}