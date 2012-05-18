using System;

namespace Meek.Caching.Events
{
    public class ItemDeletedEventArgs : EventArgs
    {
        public string ItemName { get; protected set; }

        public object ItemValue { get; protected set; }

        public ItemDeletedEventArgs(string itemName, object itemValue)
        {
            ItemValue = itemValue;
            ItemName = itemName;
        }
    }
}
