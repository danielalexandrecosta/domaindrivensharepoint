using System;
using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.SimpleAssetRepositoryTests
{
    [TestFixture]
    public class WhenAddingAssetToRepository : AssetRepositoryBase
    {
        [Test]
        public void ShouldAskListServiceForNewItemAndUpdateItemWithAsset()
        {
            listServiceMock.Setup(service => service.CreateItem()).Returns(listItemMock.Object).Verifiable();
            
            repository.Add(testAsset);

            listItemMock.Verify(item => item.Update(testAsset));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfAddIsCalledWithNullAsset()
        {
            repository.Add(null);
        }
    }
}