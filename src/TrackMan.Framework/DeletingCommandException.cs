using System;
using System.Runtime.Serialization;

namespace TrackMan.Framework
{
    public class DeletingCommandException : Exception
    {
        public DeletingCommandException()
        {
        }

        public DeletingCommandException(string message) : base(message)
        {
        }

        public DeletingCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeletingCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}