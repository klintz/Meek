using System;
using System.Collections.Generic;

namespace Meek.Event
{
    public class Dispatcher
    {
        private List<IEventListener> _listeners;
        private static Dispatcher _eventDispatcher;

        private List<IEventListener> Listeners
        {
            get
            {
                _listeners = _listeners ?? new List<IEventListener>();
                return _listeners;
            }
        }

        public void RaiseEvent(string eventName, object sender, EventArgs e)
        {
            Listeners.ForEach(l => l.Invoke(eventName, sender, e));
        }

        public void AddEventListener(IEventListener listener)
        {
            if (Equals(listener, null))
                throw new ArgumentNullException("listener");

            Listeners.Add(listener);
        }

        private Dispatcher()
        {
        }

        public static Dispatcher Current
        {
            get { _eventDispatcher = _eventDispatcher ?? new Dispatcher();
                return _eventDispatcher;
            }
        }
    }
}
