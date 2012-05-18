using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meek.Caching.Events
{
    public delegate void ItemAdded(object sender, ItemAddedEventArgs e);

    public delegate void ItemExpired(object sender, ItemExpiredEventArgs e);

    public delegate void ItemDeleted(object sender, ItemDeletedEventArgs e);
    
}
