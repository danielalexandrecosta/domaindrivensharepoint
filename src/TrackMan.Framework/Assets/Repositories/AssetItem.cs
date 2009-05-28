using TrackMan.Framework.ListServices;
using TrackMan.Framework.ListServices.FieldValues;

namespace TrackMan.Framework.Assets.Repositories
{
    public class AssetItem : IEntityItem<Asset>
    {
        private readonly IListItemWrapper spItemWrapper;

        public AssetItem(IListItemWrapper itemWrapper)
        {
            spItemWrapper = itemWrapper;
        }

        string SerialNumber
        {
            get { return new TextFieldValue(spItemWrapper, "Serial Number").Value; }
            set { new TextFieldValue(spItemWrapper, "Serial Number").Value = value; }
        }

        string Location
        {
            get { return new TextFieldValue(spItemWrapper, "Serial Number").Value; }
            set { new TextFieldValue(spItemWrapper, "Serial Number").Value = value; }
        }

        string Brand
        {
            get { return new TextFieldValue(spItemWrapper, "Brand").Value; }
            set { new TextFieldValue(spItemWrapper, "Brand").Value = value; }
        }

        decimal Cost
        {
            get { return new DecimalFieldValue(spItemWrapper, "Cost").Value; }
            set { new DecimalFieldValue(spItemWrapper, "Cost").Value = value; }
        }

        int RoomId
        {
            get
            {
                var lookupValue = new LookupFieldValue(spItemWrapper, "Room");
                return lookupValue.LookupId;
            }
            set
            {
                new LookupFieldValue(spItemWrapper, "Room").LookupId = value;
            }
        }

        public Asset CreateEntity()
        {
            return new Asset(SerialNumber)
                       {
                           Location = Location,
                           Brand = Brand,
                           Cost = Cost,
                           RoomId = RoomId
                       };
        }

        public void Update(Asset asset)
        {
            SerialNumber = asset.SerialNumber;
            Location = asset.Location;
            Brand = asset.Brand;
            Cost = asset.Cost;
            RoomId = asset.RoomId;

            spItemWrapper.Update();
        }

        public void Delete()
        {
            spItemWrapper.Delete();
        }
    }
}