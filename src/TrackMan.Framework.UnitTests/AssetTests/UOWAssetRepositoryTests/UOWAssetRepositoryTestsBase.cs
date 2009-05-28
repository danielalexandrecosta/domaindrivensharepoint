using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    public class UOWAssetRepositoryTestsBase
    {
        protected Mock<IUnitOfWork<Asset>> uowMock;
        protected Mock<IListService<Asset>> listServiceMock;
        protected Mock<IEntityItem<Asset>> listItemMock;
        protected IAssetRepository repository;
        protected Asset testAsset;

        [SetUp]
        public void SetUp()
        {
            uowMock = new Mock<IUnitOfWork<Asset>>();
            listServiceMock = new Mock<IListService<Asset>>();
            listItemMock = new Mock<IEntityItem<Asset>>();
            repository = new UOWAssetRepository(listServiceMock.Object, uowMock.Object);
            testAsset = new Asset("1234");
        }
    }
}