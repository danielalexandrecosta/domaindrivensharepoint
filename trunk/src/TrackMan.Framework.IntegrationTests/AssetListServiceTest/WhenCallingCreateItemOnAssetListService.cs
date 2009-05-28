using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories;

namespace TrackMan.Framework.IntegrationTests.AssetListServiceTest
{
    [TestFixture]
    public class WhenCallingCreateItemOnAssetListService : AssetListServiceTestBase
    {
        [Test]
        public void ShouldReturnNewAssetItem()
        {
            var item = listService.CreateItem();
            Assert.IsTrue(item is AssetItem);
        }
    }
}