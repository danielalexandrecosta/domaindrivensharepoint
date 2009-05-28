using Microsoft.SharePoint;

namespace TrackMan.Framework.ListServices.FieldValues
{
    public class LookupFieldValue
    {
        private readonly IListItemWrapper itemWrapper;
        private readonly string fieldName;

        public LookupFieldValue(IListItemWrapper itemWrapper, string fieldName)
        {
            this.itemWrapper = itemWrapper;
            this.fieldName = fieldName;
        }

        private SPFieldLookupValue SPLookupValue
        {
            get
            {
                if (itemWrapper[fieldName] == null)
                    itemWrapper[fieldName] = new SPFieldLookupValue();
                return new SPFieldLookupValue(itemWrapper[fieldName].ToString());
            }
        }

        public string LookupValue
        {
            get { return SPLookupValue.LookupValue; }
        }

        public int LookupId
        {
            get { return SPLookupValue.LookupId; }
            set { itemWrapper[fieldName] = new SPFieldLookupValue(value, null); }
        }
    }
}