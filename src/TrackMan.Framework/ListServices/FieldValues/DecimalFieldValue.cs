namespace TrackMan.Framework.ListServices.FieldValues
{
    public class DecimalFieldValue
    {
        private readonly IListItemWrapper itemWrapper;
        private readonly string fieldName;

        public DecimalFieldValue(IListItemWrapper itemWrapper, string fieldName)
        {
            this.itemWrapper = itemWrapper;
            this.fieldName = fieldName;
        }

        public decimal Value
        {
            get
            {
                decimal value = 0;
                
                if (itemWrapper[fieldName] != null)
                    decimal.TryParse(itemWrapper[fieldName].ToString(), out value);

                return value;
            }
            set { itemWrapper[fieldName] = value; }
        }
    }
}