using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests.UnitOfWorkTests
{
    [TestFixture]
    public class WhenCallingAddUpdateOnUnitOfWork : ListUnitOfWorkTestsBase
    {
        [Test]
        public void ShouldAddUnitOfWorkItemWithActionOfUpdate()
        {
            unitOfWork.AddUpdate(new TestEntity(), listItemMock.Object);
            Assert.AreEqual(1, unitOfWork.UpdateCount);
        }
    }
}