using System;

namespace Meek.Event
{
    public interface IEventListener
    {
        void Invoke(string eventName, object sender, EventArgs e);
    }
}
