﻿using System;
using Meek.Business;
using Meek.Event;
using Meek.Presentation;

namespace Meek.Web
{
    public abstract class Page : System.Web.UI.Page
    {
        protected virtual IBusinessFactory BusinessFactory
        {
            get
            {
                if(BusinessLogicManager.BusinessFactory == null)
                    throw new NullReferenceException("BusinessFactory");
                return BusinessLogicManager.BusinessFactory;
            }
        }

        protected virtual TLogic CreateBusinessLogic<TLogic>()
            where TLogic : ILogic
        {
            var logic = BusinessFactory.CreateBusinessLogic<TLogic>();
            if (Equals(logic, null))
                throw new UnableToCreateBusinessLogicException();
            return logic;
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

    public abstract class Page<TLogic> : Page
        where TLogic : ILogic
    {
        protected virtual TLogic CurrentLogic
        {
            get { return CreateBusinessLogic<TLogic>(); }
        }
    }
}
