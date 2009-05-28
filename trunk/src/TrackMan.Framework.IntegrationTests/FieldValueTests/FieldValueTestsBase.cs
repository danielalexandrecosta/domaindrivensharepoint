using Microsoft.SharePoint;
using NUnit.Framework;

namespace TrackMan.Framework.IntegrationTests.FieldValueTests
{
    public class FieldValueTestsBase : SharePointInteraction
    {
        protected SPListItem spItem;

        [SetUp]
        public virtual void SetUp()
        {
            var list = web.Lists["Assets"];
            spItem = list.Items.Add();
        }
    }
}