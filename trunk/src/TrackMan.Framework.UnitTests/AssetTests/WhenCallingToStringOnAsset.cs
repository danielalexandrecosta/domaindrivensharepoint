using NUnit.Framework;
using TrackMan.Framework.Assets;

namespace TrackMan.Framework.UnitTests.AssetTests
{
    [TestFixture]
    public class WhenCallingToStringOnAsset
    {
        [Test]
        public void ShouldReturnAssetSerialNumber()
        {
            const string serial = "1234";
            Assert.AreEqual(serial, new Asset(serial).ToString());
        }
    }
}