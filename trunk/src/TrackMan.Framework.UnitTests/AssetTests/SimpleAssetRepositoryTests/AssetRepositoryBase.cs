using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories.SimpleAssetRepository;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.SimpleAssetRepositoryTests
{
    public class AssetRepositoryBase
    {
        private const string SerialNumber = "1234";
        protected Mock<IListService<Asset>> listServiceMock;
        protected Mock<IEntityItem<Asset>> listItemMock;
        protected ISimpleAssetRepository repository;
        protected Asset testAsset;

        [SetUp]
        public virtual void SetUp()
        {
            listServiceMock = new Mock<IListService<Asset>>();
            listItemMock = new Mock<IEntityItem<Asset>>();
            repository = new SimpleAssetRepository(listServiceMock.Object);
            testAsset = new Asset(SerialNumber);
        }
    }
}