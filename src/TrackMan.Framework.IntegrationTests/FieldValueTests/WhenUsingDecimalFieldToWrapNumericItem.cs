using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories;
using TrackMan.Framework.ListServices.FieldValues;

namespace TrackMan.Framework.IntegrationTests.FieldValueTests
{
    [TestFixture]
    public class WhenUsingDecimalFieldToWrapSPFieldNumeric : FieldValueTestsBase
    {
        private DecimalFieldValue fieldValue;

        public override void SetUp()
        {
            base.SetUp();
            spItem["Cost"] = 12.95;
            fieldValue = new DecimalFieldValue(new SPListItemWrapper(spItem), "Cost");
        }
        [Test]
        public void ShouldReturnValueAssignedToSPListItemAsDecimal()
        {
            Assert.AreEqual(12.95M, fieldValue.Value);
        }

        [Test]
        public void ShouldUpdateSPFieldValueIfDecimalFieldValueIsUpdated()
        {
            fieldValue.Value = 99.95M;
            Assert.AreEqual(decimal.Parse(spItem["Cost"].ToString()), fieldValue.Value);
        }

        [Test]
        public void ShouldReturn0IfSPFieldValueIsNull()
        {
            spItem["Cost"] = null;
            Assert.AreEqual(0, fieldValue.Value);
        }
    }
}