using System;
using Meek.Event;
using Moq;
using NUnit.Framework;

namespace Test.Meek.Event
{
    [TestFixture]
    public class DispatcherTest
    {
        [Test]
        public void EventDispatcherInstanceTest()
        {
            var dispatcher = Dispatcher.Current;
            Assert.IsTrue(!Equals(dispatcher, null) && typeof(Dispatcher).IsAssignableFrom(dispatcher.GetType()));
        }

        [Test]
        public void AddListener()
        {
            var dispatcher = Dispatcher.Current;
            var listener = new Mock<IEventListener>();

            dispatcher.AddEventListener(listener.Object);
            dispatcher.RaiseEvent("testEvent", this, EventArgs.Empty);
            listener.Verify(l => l.Invoke("testEvent", this, EventArgs.Empty), Times.Once());
        }

        [Test]
        public void AddListenerNull()
        {
            var dispatcher = Dispatcher.Current;
            try
            {
                dispatcher.AddEventListener(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }

        }
    }
}
