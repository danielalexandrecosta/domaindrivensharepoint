using System;
using NUnit.Framework;

namespace TrackMan.Framework.IntegrationTests.AssetListServiceTest
{
    [TestFixture]
    public class WhenInstantiatingAssetListService
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfWebIsNull()
        {
            new Assets.Repositories.AssetListService(null);
        }
    }
}