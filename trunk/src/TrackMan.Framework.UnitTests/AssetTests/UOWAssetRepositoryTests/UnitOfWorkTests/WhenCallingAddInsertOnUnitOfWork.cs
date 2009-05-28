using System;
using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories.UOWAssetRepository.UnitOfWork;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests.UnitOfWorkTests
{
    [TestFixture]
    public class WhenCallingAddInsertOnUnitOfWork : ListUnitOfWorkTestsBase
    {
        [Test]
        public void ShouldAddUnitOfWorkItemWithActionOfAdd()
        {
            unitOfWork.AddInsert(new TestEntity(), listItemMock.Object);
            Assert.AreEqual(1, unitOfWork.InsertCount);
        }

        [Test]
        [ExpectedException(typeof(DuplicateWorkItemAddedException))]
        public void ShouldThrowExceptionIfAddingEntityThatAlreadyExists()
        {
            var entity = new TestEntity();
            unitOfWork.AddInsert(entity, listItemMock.Object);
            unitOfWork.AddInsert(entity, listItemMock.Object);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfEntityIsNull()
        {
            unitOfWork.AddInsert(null, listItemMock.Object);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfEntityItemIsNull()
        {
            unitOfWork.AddInsert(new TestEntity(), null);
        }
    }

    public class TestEntity
    {
    }
}