using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories
{
    public class AssetListService : IListService<Asset>
    {
        private const string ListName = "Assets";
        private readonly SPList list;

        public AssetListService(SPWeb web)
        {
            if(web == null)
                throw new ArgumentNullException("web");

            list = web.Lists[ListName];
        }

        public IEntityItem<Asset> CreateItem()
        {
            return new AssetItem(new SPListItemWrapper(list.Items.Add()));
        }

        public IEnumerable<IEntityItem<Asset>> Query(string queryString)
        {
            return CreateAssetItemArray(
                list.GetItems(new SPQuery { Query = queryString }));
        }

        public IEnumerable<IEntityItem<Asset>> GetAll()
        {
            return CreateAssetItemArray(list.Items);
        }

        private static IEnumerable<IEntityItem<Asset>> CreateAssetItemArray(SPListItemCollection spItems)
        {
            foreach (SPListItem item in spItems)
            {
                yield return new AssetItem(new SPListItemWrapper(item));
            }
        }
    }
}