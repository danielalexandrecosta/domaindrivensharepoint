using System;
using System.Linq;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories.SimpleAssetRepository
{
    public class SimpleAssetRepository : ISimpleAssetRepository
    {
        private readonly IListService<Asset> listService;

        public SimpleAssetRepository(IListService<Asset> listService)
        {
            this.listService = listService;
        }

        public Asset GetBySerialNumber(string serialNumber)
        {
            var assetItem = GetAssetItemBySerialNumber(serialNumber);
            return assetItem == null ? null : assetItem.CreateEntity();
        }

        public void Add(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException("asset");

            var assetItem = listService.CreateItem();
            assetItem.Update(asset);
        }

        public void Update(Asset asset)
        {
            var item = GetAssetItemBySerialNumber(asset.SerialNumber);
            if (item == null)
            {
                throw new AssetNotFoundException(
                    string.Format("No asset was found with serial number '{0}'.", asset.SerialNumber));
            }
            item.Update(asset);
        }

        public void Remove(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException("asset");

            var assetItem = GetAssetItemBySerialNumber(asset.SerialNumber);
            if (assetItem != null) assetItem.Delete();
        }

        private IEntityItem<Asset> GetAssetItemBySerialNumber(string serialNumber)
        {
            return listService.Query(string.Format(Queries.GetBySerialNumberQueryFormat, serialNumber)).FirstOrDefault();
        }
    }
}