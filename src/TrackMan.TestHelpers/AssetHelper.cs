using TrackMan.Framework.Assets;

namespace TrackMan.TestHelpers
{
    public static class AssetHelper
    {
        public static Asset CreateValidAsset()
        {
            return new Asset("12345")
                       {
                           RoomId = 1,
                           Brand = "Brand",
                           Location = "Asset location",
                           Cost = 9.95M
                       };
        }
    }
}