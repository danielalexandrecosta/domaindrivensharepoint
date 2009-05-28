using System;
using System.Runtime.Serialization;

namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork
{
    public class DuplicateWorkItemAddedException : Exception
    {
        public DuplicateWorkItemAddedException()
        {
        }

        public DuplicateWorkItemAddedException(string message) : base(message)
        {
        }

        public DuplicateWorkItemAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateWorkItemAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}