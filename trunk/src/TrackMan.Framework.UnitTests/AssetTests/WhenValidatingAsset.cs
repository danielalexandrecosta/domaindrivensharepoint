using NUnit.Framework;
using TrackMan.Framework.Assets;
using TrackMan.Framework.Validation;
using TrackMan.TestHelpers;

namespace TrackMan.Framework.UnitTests.AssetTests
{
    [TestFixture]
    public class WhenValidatingAsset
    {
        private Asset asset;

        [SetUp]
        public void SetUp()
        {
            asset = AssetHelper.CreateValidAsset();
            Assert.IsTrue(asset.IsValid());
        }

        [Test]
        public void ShouldBeInvalidIfCostIsLessThan01()
        {
            asset.Cost = 0;
            AssertAssetIsInvalidAndErrorMessageEquals("Cost must be between .01 and 1500000.");
        }

        [Test]
        public void ShouldBeInvalidIfCostIsGreaterThan1Point5Million()
        {
            asset.Cost = 2000000;
            AssertAssetIsInvalidAndErrorMessageEquals("Cost must be between .01 and 1500000.");
        }

        [Test]
        public void ShouldBeInvalidIfBrandIsEmpty()
        {
            asset.Brand = string.Empty;
            AssertAssetIsInvalidAndErrorMessageEquals("Brand cannot be blank.");
        }

        [Test]
        public void ShouldBeInvalidIfBrandIsLongerThan255Characters()
        {
            asset.Brand = new string('x', 256);
            AssertAssetIsInvalidAndErrorMessageEquals("Brand must be between 1 and 255 characters.");
        }

        [Test]
        public void ShouldBeInvalidIfLocationIsBlank()
        {
            asset.Location = string.Empty;
            AssertAssetIsInvalidAndErrorMessageEquals("Location cannot be blank.");
        }

        [Test]
        public void ShouldBeInvalidIfLocationIsLongerThan255Characters()
        {
            asset.Location = new string('x', 256);
            AssertAssetIsInvalidAndErrorMessageEquals("Location must be between 1 and 255 characters long.");
        }

        [Test]
        public void ShouldBeInvalidIfRoomIdIsZero()
        {
            asset.RoomId = 0;
            AssertAssetIsInvalidAndErrorMessageEquals("Asset must be assigned to room.");
        }

        private void AssertAssetIsInvalidAndErrorMessageEquals(string expectedErrorMessage)
        {
            Assert.IsFalse(asset.IsValid());
            Assert.AreEqual(expectedErrorMessage, asset.ErrorMessages()[0]);
        }
    }
}