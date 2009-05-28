using System;
using System.Runtime.Serialization;

namespace TrackMan.Framework.Assets.Repositories
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException()
        {
        }

        public AssetNotFoundException(string message) : base(message)
        {
        }

        public AssetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AssetNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}