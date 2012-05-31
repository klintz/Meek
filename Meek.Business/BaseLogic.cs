using System;
using Meek.Data;
using Meek.Event;

namespace Meek.Business
{
    public abstract class BaseLogic : ILogic
    {
        protected virtual IDataSessionFactory DataSessionFactory
        {
            get
            {
                if(DataSessionManager.DataSessionFactory == null)
                    throw new NullReferenceException("DataSessionFactory");
                return DataSessionManager.DataSessionFactory;
            }
        }

        protected virtual TDataSession CreateDataSession<TDataSession>()
            where TDataSession : IDataSession
        {
            var session = DataSessionFactory.CreateDataSession<TDataSession>();
            if (Equals(session, null))
                throw new UnableToCreateDataSessionException();
            return session;
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

    public abstract class BaseLogic<TDataSession> : BaseLogic
        where TDataSession : IDataSession
    {
        protected virtual TDataSession DataSession
        {
            get { return CreateDataSession<TDataSession>(); }
        }
    }

}

