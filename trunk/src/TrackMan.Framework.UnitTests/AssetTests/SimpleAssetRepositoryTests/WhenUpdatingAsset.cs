using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.SimpleAssetRepositoryTests
{
    [TestFixture]
    public class WhenUpdatingAsset : AssetRepositoryBase
    {
        [Test]
        [ExpectedException(typeof(AssetNotFoundException))]
        public void ShouldThrowExceptionIfAssetCannotBeFoundInList()
        {
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new IEntityItem<Asset>[] { });
            repository.Update(new Asset("1234"));
        }

        [Test]
        public void ShouldCallUpdateOnAssetItemIfAssetWasFound()
        {
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new[] { listItemMock.Object });
            repository.Update(testAsset);
            listItemMock.Verify(item => item.Update(testAsset));
        }
    }
}