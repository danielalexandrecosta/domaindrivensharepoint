using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests.UnitOfWorkTests
{
    [TestFixture]
    public class WhenCallingUpdateOnUnitOfWork : ListUnitOfWorkTestsBase
    {
        [Test]
        public void ShouldMoveItemsWithActionOfAddToActionOfUpdate()
        {
            unitOfWork.AddInsert(new TestEntity(), listItemMock.Object);
            unitOfWork.Update();
            
            Assert.AreEqual(1, unitOfWork.UpdateCount);
        }

        [Test]
        public void ShouldCallUpdateOnListItemWhenUpdateIsCalledOnUnitOfWorkItemWithActionOfAdd()
        {
            var testEntity = new TestEntity();
            unitOfWork.AddInsert(testEntity, listItemMock.Object);

            unitOfWork.Update();

            listItemMock.Verify(item => item.Update(testEntity));
            Assert.AreEqual(0, unitOfWork.InsertCount);
            Assert.AreEqual(1, unitOfWork.UpdateCount);
        }

        [Test]
        public void ShouldCallUpdateOnListItemWhenUpdateIsCalledOnUnitOfWorkItemWithActionOfUpdate()
        {
            var testEntity = new TestEntity();
            unitOfWork.AddUpdate(testEntity, listItemMock.Object);

            unitOfWork.Update();

            listItemMock.Verify(item => item.Update(testEntity));
            Assert.AreEqual(1, unitOfWork.UpdateCount);
        }

        [Test]
        public void ShouldCallDeleteOnListItemWhenUpdateIsCalledOnUnitOfWorkItemWithActionOfDelete()
        {
            var testEntity = new TestEntity();
            unitOfWork.AddInsert(testEntity, listItemMock.Object);
            unitOfWork.AddDelete(testEntity);

            unitOfWork.Update();

            Assert.AreEqual(0, unitOfWork.DeleteCount);
            listItemMock.Verify(item => item.Delete());
        }
    }
}