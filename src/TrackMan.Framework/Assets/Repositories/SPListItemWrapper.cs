using Microsoft.SharePoint;
using TrackMan.Framework.ListServices;

namespace TrackMan.Framework.Assets.Repositories
{
    public class SPListItemWrapper : IListItemWrapper
    {
        private readonly SPListItem item;

        public SPListItemWrapper(SPListItem item)
        {
            this.item = item;
        }

        public object this[string fieldName]
        {
            get { return item[fieldName]; }
            set { item[fieldName] = value; }
        }

        public void Update()
        {
            item.Update();
        }

        public void Delete()
        {
            item.Delete();
        }
    }
}