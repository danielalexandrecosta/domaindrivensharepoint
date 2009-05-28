using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories;
using TrackMan.Framework.ListServices.FieldValues;

namespace TrackMan.Framework.IntegrationTests.FieldValueTests
{
    [TestFixture]
    public class WhenUsingTextFieldValueToWrapSPField : FieldValueTestsBase
    {
        private TextFieldValue textFieldValue;

        public override void SetUp()
        {
            base.SetUp();
            spItem["Serial Number"] = "1234";
            textFieldValue = new TextFieldValue(new SPListItemWrapper(spItem), "Serial Number");
        }

        [Test]
        public void ShouldReturnStringValueForTextField()
        {
            Assert.AreEqual("1234", textFieldValue.Value);
        }

        [Test]
        public void ShouldUpdateStringValueWithAssignedValue()
        {
            textFieldValue.Value = "5678";
            Assert.AreEqual("5678", spItem["Serial Number"].ToString());
        }

        [Test]
        public void ShouldReturnEmptyStringIfValueIsNull()
        {
            spItem["Serial Number"] = null;
            Assert.AreEqual(string.Empty, textFieldValue.Value);
        }
    }
}