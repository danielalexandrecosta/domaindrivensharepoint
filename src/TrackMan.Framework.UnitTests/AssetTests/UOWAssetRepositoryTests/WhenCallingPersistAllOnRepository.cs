using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenCallingPersistAllOnRepository : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldCallUpdateOnUnitOfWork()
        {
            repository.PersistAll();
            uowMock.Verify(uow => uow.Update());
        }
    }
}