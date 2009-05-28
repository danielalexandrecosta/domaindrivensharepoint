using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.SimpleAssetRepositoryTests
{
    [TestFixture]
    public class WhenGettingAssetFromRepositoryBySerialNumber : AssetRepositoryBase
    {
        [Test]
        public void ShouldReturnNullIfAssetSerialNumberDoesNotExist()
        {
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new IEntityItem<Asset>[] { });

            var asset = repository.GetBySerialNumber(testAsset.SerialNumber);

            Assert.IsNull(asset);
        }

        [Test]
        public void ShouldReturnAssetIfAssetWithSerialNumberExists()
        {
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new[] { listItemMock.Object });
            listItemMock.Setup(item => item.CreateEntity()).Returns(testAsset);

            var asset = repository.GetBySerialNumber(testAsset.SerialNumber);
            Assert.AreSame(testAsset, asset);
        }
    }
}