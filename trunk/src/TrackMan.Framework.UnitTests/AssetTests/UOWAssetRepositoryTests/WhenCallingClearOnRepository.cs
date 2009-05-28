using NUnit.Framework;

namespace TrackMan.Framework.UnitTests.AssetTests.UOWAssetRepositoryTests
{
    [TestFixture]
    public class WhenCallingClearOnRepository : UOWAssetRepositoryTestsBase
    {
        [Test]
        public void ShouldCallClearOnUnitOfWork()
        {
            repository.Clear();
            uowMock.Verify(uow => uow.Clear());
        }
    }
}