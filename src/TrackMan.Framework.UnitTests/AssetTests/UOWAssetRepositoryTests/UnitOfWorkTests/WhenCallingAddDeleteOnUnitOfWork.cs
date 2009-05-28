using System;
using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests.UnitOfWorkTests
{
    [TestFixture]
    public class WhenCallingAddDeleteOnUnitOfWork : ListUnitOfWorkTestsBase
    {
        [Test]
        public void ShouldAddUnitOfWorkItemWithActionOfDelete()
        {
            var testEntity = new TestEntity();
            unitOfWork.AddInsert(testEntity, listItemMock.Object);
            unitOfWork.AddDelete(testEntity);

            Assert.AreEqual(0, unitOfWork.InsertCount);
            Assert.AreEqual(1, unitOfWork.DeleteCount);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionIfEntityIsNotInUnitOfWork()
        {
            unitOfWork.AddDelete(new TestEntity());
        }
    }
}