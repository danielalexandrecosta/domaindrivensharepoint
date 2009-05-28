using NUnit.Framework;
using TrackMan.Framework.Assets;

namespace TrackMan.Framework.UnitTests.AssetTests
{
    [TestFixture]
    public class WhenComparingTwoAssets
    {
        [Test]
        public void ShouldReturnTrueWhenTwoAssetsHaveTheSameSerialNumber()
        {
            const string serial = "12345";
            var asset1 = new Asset(serial);
            var asset2 = new Asset(serial);

            Assert.IsTrue(asset1.Equals(asset2));
        }

        [Test]
        public void ShouldReturnFalseWhenAssetsHaveDifferentSerialNumbers()
        {
            var asset1 = new Asset("1234");
            var asset2 = new Asset("123");

            Assert.IsFalse(asset1.Equals(asset2));
        }

        [Test]
        public void ShouldReturnFalseWhenComparedToAssetIsNull()
        {
            var asset1 = new Asset("1234");

            Assert.IsFalse(asset1.Equals(null));
        }
    }
}