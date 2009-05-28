using Microsoft.SharePoint;
using NUnit.Framework;

namespace TrackMan.Framework.IntegrationTests
{
    public class SharePointInteraction
    {
        private SPSite site;
        protected SPWeb web;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            site = new SPSite("http://winsrv2008");
            web = site.OpenWeb();
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
            if(web != null)
            {
                web.Dispose();
                web = null;
            }
            if(site != null)
            {
                site.Dispose();
                site = null;
            }
        }
    }
}