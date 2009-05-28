using System;
using System.Runtime.Serialization;

namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository
{
    public class DuplicateItemAddedException : Exception 
    {
        public DuplicateItemAddedException()
        {
        }

        public DuplicateItemAddedException(string message) : base(message)
        {
        }

        public DuplicateItemAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateItemAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}