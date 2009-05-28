using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenGettingAnAssetBySerialNumber : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldReturnNullIfNoAssetExistsWithSerialNumber()
        {
            listServiceMock.Setup(service => service.Query(
                It.IsAny<string>())).Returns(new IEntityItem<Asset>[] { });

            Assert.IsNull(repository.GetBySerialNumber("1234"));
        }

        [Test]
        public void ShouldReturnAssetAndAddToUnitOfWorkUpdateListIfAssetIsInListAndNotUnitOfWork()
        {
            var assetFromQuery = new Asset(testAsset.SerialNumber);
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new[] { listItemMock.Object });
            listItemMock.Setup(item => item.CreateEntity()).Returns(assetFromQuery);
            uowMock.Setup(uow => uow.Contains(assetFromQuery)).Returns(false);

            var asset = repository.GetBySerialNumber(testAsset.SerialNumber);
            
            Assert.AreSame(assetFromQuery, asset);
            uowMock.Verify(uow => uow.AddUpdate(assetFromQuery, listItemMock.Object));
        }

        [Test]
        public void ShouldReturnAssetFromUnitOfWorkIfAssetExists()
        {
            var assetFromQuery = new Asset(testAsset.SerialNumber);
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new[] { listItemMock.Object });
            listItemMock.Setup(item => item.CreateEntity()).Returns(assetFromQuery);
            uowMock.Setup(uow => uow.Contains(assetFromQuery)).Returns(true);
            uowMock.Setup(uow => uow.Get(assetFromQuery)).Returns(testAsset).Verifiable();

            var result = repository.GetBySerialNumber(testAsset.SerialNumber);
            Assert.AreSame(testAsset, result);
        }
    }
}