using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenCallingGetByRoomIdOnAssetRepository : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldExecuteGetByRoomQueryAndReturnAssetsInRoom()
        {
            const int roomId = 10;
            var asset = new Asset("1234");

            listItemMock.Setup(item => item.CreateEntity()).Returns(asset);
            listServiceMock.Setup(service => service.Query(
                string.Format(Queries.GetByRoomId, roomId))).Returns(new[] { listItemMock.Object });
            uowMock.Setup(uow => uow.Contains(asset)).Returns(false);
            
            var assets = repository.GetByRoomId(roomId);
            Assert.AreEqual(1, assets.Length);

            uowMock.Verify(uow => uow.Get(asset), Times.Never());
            uowMock.Verify(uow => uow.AddUpdate(asset, listItemMock.Object));
        }

        [Test]
        public void ShouldReturnAssetsFromUnitOfWorkIfTheyExistForRoomId()
        {
            const int roomId = 10;
            var asset = new Asset("1234");

            listItemMock.Setup(item => item.CreateEntity()).Returns(asset);
            listServiceMock.Setup(service => service.Query(
                string.Format(Queries.GetByRoomId, roomId))).Returns(new[] { listItemMock.Object });
            uowMock.Setup(uow => uow.Contains(asset)).Returns(true);
            uowMock.Setup(uow => uow.Get(asset)).Returns(asset).Verifiable();

            var assets = repository.GetByRoomId(roomId);
            Assert.AreEqual(1, assets.Length);
            uowMock.VerifyAll();
        }
    }
}