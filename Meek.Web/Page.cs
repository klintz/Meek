using System;
using Meek.Business;
using Meek.Event;

namespace Meek.Web
{
    public abstract class Page : System.Web.UI.Page
    {
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

    public abstract class Page<TLogic> : Page
        where TLogic : ILogic
    {
        protected abstract TLogic CurrentLogic { get; }
    }
}
