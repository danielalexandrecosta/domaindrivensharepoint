using System;
using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenAddingAssetToRepository : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldAddAssetToAddInsertUnitOfWork()
        {
            listServiceMock.Setup(service => service.CreateItem()).Returns(listItemMock.Object);
            
            repository.Add(testAsset);
            
            uowMock.Verify(uow => uow.AddInsert(testAsset, listItemMock.Object));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfAssetIsNull()
        {
            repository.Add(null);
        }
    }
}