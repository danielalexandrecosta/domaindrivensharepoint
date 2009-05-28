using System;
using NUnit.Framework;
using TrackMan.Framework.Assets;

namespace TrackMan.Framework.UnitTests.AssetTests
{
    [TestFixture]
    public class WhenCreatingNewAsset
    {
        [Test]
        public void ShouldSetSerialNumberToValuePassedToConstructor()
        {
            const string serial = "1234";
            Assert.AreEqual(serial, new Asset(serial).SerialNumber);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), 
            ExpectedMessage = "Serial number cannot be empty or null.")]
        public void ShouldThrowExceptionIfSerialNumberIsEmpty()
        {
            new Asset(string.Empty);
        }

    }
}