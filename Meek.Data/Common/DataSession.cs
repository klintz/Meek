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

        public virtual void BeginTransaction()
        {
            Provider.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            Provider.CommitTransaction();
        }

        public virtual void RollbackTransaction()
        {
            Provider.RollbackTransaction();
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
