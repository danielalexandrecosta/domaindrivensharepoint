using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace TrackMan.TestHelpers
{
    public static class ListTestExtensions
    {
        public static List<SPListItem> Where(this SPListItemCollection items, Func<SPListItem, bool> where)
        {
            var matchingItems = new List<SPListItem>();
            foreach(SPListItem item in items)
            {
                if(where(item))
                    matchingItems.Add(item);
            }
            return matchingItems;
        }
    }
}