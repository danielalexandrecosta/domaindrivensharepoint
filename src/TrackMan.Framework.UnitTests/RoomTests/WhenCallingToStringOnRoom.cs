using NUnit.Framework;
using TrackMan.Framework.Rooms;

namespace TrackMan.Framework.UnitTests.RoomTests
{
    [TestFixture]
    public class WhenCallingToStringOnRoom
    {
        [Test]
        public void ShouldReturnRoomNumber()
        {
            Assert.AreEqual("1", new Room(1, "1").ToString());
        }
    }
}