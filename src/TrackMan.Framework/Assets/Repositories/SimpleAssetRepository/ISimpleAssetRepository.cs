namespace TrackMan.Framework.Assets.Repositories.SimpleAssetRepository
{
    public interface ISimpleAssetRepository
    {
        Asset GetBySerialNumber(string serialNumber);
        void Add(Asset asset);
        void Update(Asset asset);
        void Remove(Asset asset);
    }
}