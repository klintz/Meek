using System;

namespace Meek.Caching.Events
{
    public class ItemExpiredEventArgs : EventArgs
    {
        public string ItemName { get; protected set; }

        public object ItemValue { get; protected set; }

        public ItemExpiredEventArgs(string itemName, object itemValue)
        {
            ItemValue = itemValue;
            ItemName = itemName;
        }
    }
}
