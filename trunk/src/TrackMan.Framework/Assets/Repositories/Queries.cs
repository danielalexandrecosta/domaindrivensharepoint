using System.Reflection;
using System.Resources;

namespace TrackMan.Framework.Assets.Repositories
{
    public static class Queries
    {
        private static readonly ResourceManager Manager =
            new ResourceManager("TrackMan.Framework.Resources.AssetQueries", Assembly.GetExecutingAssembly());

        public static readonly string GetBySerialNumberQueryFormat = Manager.GetString("GetBySerialNumberQuery");
        public static readonly string GetByRoomId = Manager.GetString("GetByRoomIdQuery");
    }
}