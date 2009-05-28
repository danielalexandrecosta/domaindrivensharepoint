using System;
using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenRemovingAssetFromRepository : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldMoveAssetFromUpdateListToRemoveListInUnitOfWork()
        {
            repository.Remove(testAsset);
            uowMock.Verify(uow => uow.AddDelete(testAsset));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfAssetIsNull()
        {
            repository.Remove(null);
        }
    }
}