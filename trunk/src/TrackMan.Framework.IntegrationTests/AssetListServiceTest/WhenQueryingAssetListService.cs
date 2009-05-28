using System.Collections.Generic;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.IntegrationTests.AssetListServiceTest
{
    [TestFixture]
    public class WhenQueryingAssetListService : AssetListServiceTestBase
    {
        [Test]
        public void ShouldReturnOneItemForQueryBySerialNumberIfOneItemIsInList()
        {
            AddItemWithSerialNumber("1234");
            AddItemWithSerialNumber("5678");

            var results = QueryBySerialNumberEqualTo("1234");

            AssertItemCountForEnumeratorIsEqualTo(1, results.GetEnumerator());
        }

        [Test]
        public void ShouldReturnMultipleItemsIfMultipleItemsWithSerialNumberExist()
        {
            AddItemWithSerialNumber("1234");
            AddItemWithSerialNumber("1234");
            AddItemWithSerialNumber("5678");

            var results = QueryBySerialNumberEqualTo("1234");

            AssertItemCountForEnumeratorIsEqualTo(2, results.GetEnumerator());
        }

        [Test]
        public void ShouldReturnEmptyEnumeratorIfNoItemsWithSerialNumberExist()
        {
            var results = QueryBySerialNumberEqualTo("9999");
            AssertItemCountForEnumeratorIsEqualTo(0, results.GetEnumerator());
        }
        
        [Test]
        public void ShouldReturnEmptyEnumeratorIfQueryIsBlank()
        {
            var results = listService.Query(string.Empty);

            AssertItemCountForEnumeratorIsEqualTo(0, results.GetEnumerator());
        }

        [Test]
        public void ShouldReturnEmptyEnumeratorIfQueryIsNull()
        {
            var results = listService.Query(string.Empty);

            AssertItemCountForEnumeratorIsEqualTo(0, results.GetEnumerator());
        }

        #region Helper methods

        private IEnumerable<IEntityItem<Asset>> QueryBySerialNumberEqualTo(string serialNumber)
        {
            return listService.Query(string.Format(Queries.GetBySerialNumberQueryFormat, serialNumber));
        }

        #endregion
    }
}