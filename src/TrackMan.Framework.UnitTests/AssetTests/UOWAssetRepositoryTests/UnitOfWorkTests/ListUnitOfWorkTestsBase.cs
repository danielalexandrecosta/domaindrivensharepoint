using Moq;
using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests.UnitOfWorkTests
{
    public class ListUnitOfWorkTestsBase
    {
        protected IUnitOfWork<TestEntity> unitOfWork;
        protected Mock<IEntityItem<TestEntity>> listItemMock;

        [SetUp]
        public void SetUp()
        {
            unitOfWork = new ListUnitOfWork<TestEntity>();
            listItemMock = new Mock<IEntityItem<TestEntity>>();
        }
    }
}