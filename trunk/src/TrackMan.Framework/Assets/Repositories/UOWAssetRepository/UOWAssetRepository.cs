using System;
using System.Collections.Generic;
using System.Linq;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories.UOWAssetRepository
{
    public class UOWAssetRepository : IAssetRepository
    {
        private readonly IListService<Asset> listService;
        private readonly IUnitOfWork<Asset> unitOfWork;

        public UOWAssetRepository(IListService<Asset> listService, IUnitOfWork<Asset> unitOfWork)
        {
            this.listService = listService;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Asset asset)
        {
            AssertAssetIsValid(asset);

            var assetItem = listService.CreateItem();
            unitOfWork.AddInsert(asset, assetItem);
        }

        public void Remove(Asset asset)
        {
            AssertAssetIsValid(asset);

            unitOfWork.AddDelete(asset);
        }

        public Asset GetBySerialNumber(string serialNumber)
        {
            var assetItem = listService.Query(
                string.Format(Queries.GetBySerialNumberQueryFormat, serialNumber)).FirstOrDefault();

            if (assetItem == null)
                return null;

            var asset = assetItem.CreateEntity();
            if (unitOfWork.Contains(asset))
                return unitOfWork.Get(asset);

            unitOfWork.AddUpdate(asset, assetItem);

            return asset;
        }

        public Asset[] GetByRoomId(int roomId)
        {
            var assetItems = listService.Query(string.Format(Queries.GetByRoomId, roomId));
            return CreateAssetArrayFromListItems(assetItems);
        }

        public void PersistAll()
        {
            unitOfWork.Update();
        }

        public void Clear()
        {
            unitOfWork.Clear();
        }

        #region Helper methods

        private Asset[] CreateAssetArrayFromListItems(IEnumerable<IEntityItem<Asset>> assetItems)
        {
            var assetList = new List<Asset>();
            foreach (var assetItem in assetItems)
            {
                var asset = assetItem.CreateEntity();
                if (unitOfWork.Contains(asset))
                {
                    assetList.Add(unitOfWork.Get(asset));
                }else
                {
                    unitOfWork.AddUpdate(asset, assetItem);
                    assetList.Add(asset);
                }
            }
            return assetList.ToArray();
        }

        private static void AssertAssetIsValid(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException("asset");
        }

        #endregion
    }
}