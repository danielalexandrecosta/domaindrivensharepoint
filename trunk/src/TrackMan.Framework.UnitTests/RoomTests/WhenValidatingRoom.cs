using NUnit.Framework;
using TrackMan.Framework.Rooms;
using TrackMan.Framework.Validation;

namespace TrackMan.Framework.UnitTests.RoomTests
{
    [TestFixture]
    public class WhenValidatingRoom
    {
        private Room room;

        [Test]
        public void ShouldBeInvalidIfIdIsLessThanZero()
        {
            room = new Room(-1, "Room");
            AssertRoomIsInvalidAndErrorMessageEquals("Room ID must be greater than 0.");
        }

        [Test]
        public void ShouldBeInvalidIfRoomNumberIsBlank()
        {
            room = new Room(1, string.Empty);
            AssertRoomIsInvalidAndErrorMessageEquals("Room Number must be specified.");
        }

        [Test]
        public void ShouldBeInvalidIfRoomNumberIsTooLong()
        {
            room = new Room(1, new string('x', 256));
            AssertRoomIsInvalidAndErrorMessageEquals("Room Number must be between 1 and 255 characters.");
        }

        private void AssertRoomIsInvalidAndErrorMessageEquals(string expectedErrorMessage)
        {
            Assert.IsFalse(room.IsValid());
            Assert.AreEqual(expectedErrorMessage, room.ErrorMessages()[0]);
        }
    }
}