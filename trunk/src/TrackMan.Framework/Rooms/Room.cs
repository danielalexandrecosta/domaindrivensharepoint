using System;
using Castle.Components.Validator;

namespace TrackMan.Framework.Rooms
{
    public class Room
    {
        public Room() : this(0, string.Empty) { }
        public Room(int id, string roomNumber)
        {
            Id = id;
            Number = roomNumber;
        }

        [ValidateRange(0, int.MaxValue, "RoomIdRange")]
        public int Id { get; set; }
        [ValidateNonEmpty("RoomNumberBlank")]
        [ValidateLength(1, 255, "RoomNumberLength")]
        public string Number { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Room;
            return (other != null && other.Id == Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Number;
        }
    }
}