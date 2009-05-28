using Microsoft.SharePoint;
using NUnit.Framework;
using TrackMan.Framework.Assets.Repositories;
using TrackMan.Framework.ListServices.FieldValues;

namespace TrackMan.Framework.IntegrationTests.FieldValueTests
{
    [TestFixture]
    public class WhenUsingLookupFieldValueToWrapSPFieldLookup : FieldValueTestsBase
    {
        private SPList roomList;
        private SPList assetList;
        private SPListItem assetItem;
        private LookupFieldValue lookupField;

        private int roomId1;
        private int roomId2;

        #region SetUp/TearDown

        public override void SetUp()
        {
            base.TestFixtureSetUp();
            roomList = web.Lists["Rooms"];
            var roomItem1 = roomList.Items.Add();
            roomItem1["Room Number"] = "Room 1";
            roomItem1.Update();
            roomId1 = roomItem1.ID;

            var roomItem2 = roomList.Items.Add();
            roomItem2["Room Number"] = "Room 2";
            roomItem2.Update();
            roomId2 = roomItem2.ID;

            assetList = web.Lists["Assets"];
            assetItem = assetList.Items.Add();
            assetItem["Room"] = new SPFieldLookupValue(roomId1, null);
            assetItem.Update();

            lookupField = new LookupFieldValue(new SPListItemWrapper(assetItem), "Room");
        }

        [TearDown]
        public void TearDown()
        {
            for (var i = roomList.Items.Count - 1; i >= 0; i--)
            {
                roomList.Items.Delete(i);
            }
            for (var i = assetList.Items.Count - 1; i >= 0; i--)
            {
                assetList.Items.Delete(i);
            }
            base.TestFixtureTearDown();
        }

        #endregion

        [Test]
        public void ShouldReturnIdOfRoomAddedToAsset()
        {
            Assert.AreEqual(roomId1, lookupField.LookupId);
        }

        [Test]
        public void ShouldUpdateIdValueToValueAssigned()
        {
            lookupField.LookupId = roomId2;
            Assert.AreEqual(roomId2, lookupField.LookupId);    
        }

        [Test]
        public void ShouldUpdateItemValueIfIdIsUpdatedToExistingRoomAndAssetItemIsUpdated()
        {
            lookupField.LookupId = roomId2;
            assetItem.Update();
            Assert.AreEqual("Room 2", lookupField.LookupValue);
        }
    }
}