using System;
using Moq;
using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.SimpleAssetRepositoryTests
{
    [TestFixture]
    public class WhenRemovingAssetFromRepository : AssetRepositoryBase
    {
        [Test]
        public void ShouldCallAddForDeleteOnUnitOfWorkIfNotInUnitOfWork()
        {
            listServiceMock.Setup(service => service.Query(It.IsAny<string>())).Returns(new[] {listItemMock.Object});

            repository.Remove(testAsset);

            listItemMock.Verify(item => item.Delete());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfAssetIsNull()
        {
            repository.Remove(null);
        }
    }
}