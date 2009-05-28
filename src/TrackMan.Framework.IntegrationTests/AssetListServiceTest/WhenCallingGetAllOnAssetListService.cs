using NUnit.Framework;

namespace TrackMan.Framework.IntegrationTests.AssetListServiceTest
{
    [TestFixture]
    public class WhenCallingGetAllOnAssetListService : AssetListServiceTestBase
    {
        [Test]
        public void ShouldReturnEmptyEnumeratorIfNoItemsAreInTheList()
        {
            AssertItemCountForEnumeratorIsEqualTo(0, listService.GetAll().GetEnumerator());
        }

        [Test]
        public void ShouldReturnSingleItemInEnumeratorIfOneItemInList()
        {
            AddOneItemToList();
            AssertItemCountForEnumeratorIsEqualTo(1, listService.GetAll().GetEnumerator());
        }

        [Test]
        public void ShouldReturnThreeItemsIfThreeItemsAreInTheList()
        {
            AddThreeItemsToList();
            AssertItemCountForEnumeratorIsEqualTo(3, listService.GetAll().GetEnumerator());
        }

        private void AddThreeItemsToList()
        {
            AddOneItemToList();
            AddOneItemToList();
            AddOneItemToList();
        }

        private void AddOneItemToList()
        {
            var item = assetList.Items.Add();
            item.Update();
        }
    }
}