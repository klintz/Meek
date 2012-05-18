using System;
using System.Collections.Generic;

namespace Meek.Event
{
    public abstract class EventListener : IEventListener
    {
        private Dictionary<string, EventHandler> _handlers;

        private Dictionary<string, EventHandler> Handlers
        {
            get
            {
                _handlers = _handlers ?? new Dictionary<string, EventHandler>();
                return _handlers;
            }
        }

        protected void AddEventHandler(string eventName, EventHandler handler)
        {
            Handlers.Add(eventName, handler);
        }

        void IEventListener.Invoke(string eventName, object sender, EventArgs e)
        {
            if (!Handlers.ContainsKey(eventName))
                return;

            Handlers[eventName].Invoke(sender, e);
        }
    }
}
