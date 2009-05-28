namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository
{
    public interface IAssetRepository
    {
        void Add(Asset asset);
        void Remove(Asset asset);
        Asset GetBySerialNumber(string serialNumber);
        Asset[] GetByRoomId(int roomId);
        void PersistAll();
        void Clear();
    }
}