using NUnit.Framework;
using TrackMan.Framework.Rooms;

namespace TrackMan.Framework.UnitTests.RoomTests
{
    [TestFixture]
    public class WhenComparingTwoRooms
    {
        [Test]
        public void ShouldBeEqualIfRoomsHaveSameIdAndRoomNumber()
        {
            Assert.AreEqual(new Room(1, "1"), new Room(1, "1"));
        }

        [Test]
        public void ShouldBeEqualIfRoomsHaveSameIdAndDifferentRoomNumber()
        {
            Assert.AreEqual(new Room(1, "1"), new Room(1, "2"));
        }

        [Test]
        public void ShouldNotBeEqualIfRoomsHaveDifferentId()
        {
            Assert.AreNotEqual(new Room(1, "1"), new Room(2, "1"));
        }

        [Test]
        public void ShouldNotBeEqualIfOneRoomIsNull()
        {
            Assert.AreNotEqual(new Room(1, "1"), null);
        }
    }
}