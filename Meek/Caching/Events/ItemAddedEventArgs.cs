using System;

namespace Meek.Caching.Events
{
    public class ItemAddedEventArgs : EventArgs
    {
        public string ItemName { get; protected set; }

        public object ItemValue { get; protected set; }

        public ItemAddedEventArgs(string itemName, object itemValue)
        {
            ItemValue = itemValue;
            ItemName = itemName;
        }
    }
}
