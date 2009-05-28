using Moq;
using NUnit.Framework;
using TrackMan.Framework.ListServices;
using TrackMan.Framework.Rooms;
using TrackMan.Framework.Rooms.Repository;

namespace TrackMan.Framework.UnitTests.RoomTests.RepositoryTests
{
    [TestFixture]
    public class WhenCallingGetRoomsOnRepository
    {
        private RoomRepository repository;
        private Mock<IListService<Room>> listServiceMock;

        [SetUp]
        public void SetUp()
        {
            listServiceMock = new Mock<IListService<Room>>();
            repository = new RoomRepository(listServiceMock.Object);
        }

        [Test]
        public void ShouldReturnEmptyRoomArrayIfNoRoomsExist()
        {
            listServiceMock.Setup(service => service.GetAll()).Returns(new IEntityItem<Room>[] { });
            var rooms = repository.GetRooms();

            Assert.AreEqual(0, rooms.Length);
        }

        [Test]
        public void ShouldReturnAllRooms()
        {
            var listItem1Mock = new Mock<IEntityItem<Room>>();
            var listItem2Mock = new Mock<IEntityItem<Room>>();

            var room1 = new Room(1, "Room 1");
            var room2 = new Room(2, "Room 2");

            listServiceMock.Setup(service => service.GetAll()).Returns(new[] { listItem1Mock.Object, listItem2Mock.Object });
            listItem1Mock.Setup(item1 => item1.CreateEntity()).Returns(room1);
            listItem2Mock.Setup(item1 => item1.CreateEntity()).Returns(room2);

            var rooms = repository.GetRooms();

            Assert.AreEqual(2, rooms.Length);
            Assert.AreSame(room1, rooms[0]);
            Assert.AreSame(room2, rooms[1]);
        }
    }
}