using System;
using Meek.Event;

namespace Meek.Data.Common
{
    public abstract class DataSession: IDataSession
    {
        public IDataProvider Provider { get; set; }

        protected DataSession(IDataProvider provider)
        {
            Provider = provider;
        }

        protected virtual void RaiseEvent(string eventName)
        {
            Dispatcher.Current.RaiseEvent(eventName, this, null);
        }

        protected virtual void RaiseEvent(string eventName, EventArgs args)
        {
            Dispatcher.Current.RaiseEvent(eventName, this, args);
        }

        protected virtual void RaiseEvent(string eventName, object sender, EventArgs args)
        {
            Dispatcher.Current.RaiseEvent(eventName, sender, args);
        }

    }
}
