namespace TrackMan.Framework.ListServices.FieldValues
{
    public class TextFieldValue
    {
        private readonly IListItemWrapper itemWrapper;
        private readonly string fieldName;

        public TextFieldValue(IListItemWrapper itemWrapper, string fieldName)
        {
            this.itemWrapper = itemWrapper;
            this.fieldName = fieldName;
        }

        public string Value
        {
            get
            {
                var value = string.Empty;
                
                if (itemWrapper[fieldName] != null)
                    value = itemWrapper[fieldName].ToString();
                
                return value;
            }
            set{ itemWrapper[fieldName] = value;}
        }
    }
}