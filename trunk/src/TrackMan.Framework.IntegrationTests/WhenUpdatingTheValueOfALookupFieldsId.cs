using Microsoft.SharePoint;
using NUnit.Framework;

namespace TrackMan.Framework.IntegrationTests
{
    [TestFixture]
    public class WhenUpdatingTheValueOfALookupFieldsId
    {
        [Test]
        [Ignore("Exploratory test...")]
        public void ShouldItAlsoUpdateTheLookupValue()
        {
            using (var site = new SPSite("http://winsrv2008"))
            using (var web = site.OpenWeb())
            {
                var list = web.Lists["Assets"];
                var item = list.GetItemById(262);
                item["Room"] = new SPFieldLookupValue(19, null);
                item.Update();
            }

        }
    }
}