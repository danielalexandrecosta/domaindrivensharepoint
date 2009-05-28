using System.Collections;
using Microsoft.SharePoint;
using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories;

namespace TrackMan.Framework.IntegrationTests.AssetListServiceTest
{
    public class AssetListServiceTestBase : SharePointInteraction
    {
        protected AssetListService listService;
        protected SPList assetList;
        private const string AssetListName = "Assets";

        [SetUp]
        public virtual void SetUp()
        {
            listService = new AssetListService(web);
            assetList = web.Lists[AssetListName];
        }

        [TearDown]
        public void TearDown()
        {
            ClearList();
        }

        private void ClearList()
        {
            for (var i = assetList.Items.Count - 1; i >= 0; i--)
            {
                assetList.Items.Delete(i);
            }
        }

        protected static void AssertItemCountForEnumeratorIsEqualTo(int expectedCount, IEnumerator enumerator)
        {
            for (var i = 0; i < expectedCount; i++)
            {
                Assert.IsTrue(enumerator.MoveNext(), "Enumerator should contain a next item.");
            }
            Assert.IsFalse(enumerator.MoveNext(), "Enumerator should not contain a next item.");
        }

        protected void AddItemWithSerialNumber(string serialNumber)
        {
            var item = assetList.Items.Add();
            item["Serial Number"] = serialNumber;
            item.Update();
        }
    }
}