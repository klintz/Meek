using System;
using System.Linq;
using Meek.Data.Extension.Schema.Collection;

namespace Meek.Data.Extension
{
    public class DataSessionFactory : IDataSessionFactory
    {
        private DataSessionItemCollection _dataSessionItemCollection;

        public virtual DataSessionItemCollection DataSessionItemCollection
        {
            get { _dataSessionItemCollection = _dataSessionItemCollection ?? new DataSessionItemCollection();
                return _dataSessionItemCollection;
            }
            set { _dataSessionItemCollection = value; }
        }

        public TDataSession CreateDataSession<TDataSession>()
           where TDataSession : IDataSession
        {
            var type = typeof (TDataSession);
            var item = DataSessionItemCollection.SingleOrDefault(i => i.Base == type.FullName && i.IsActive);

            if (Equals(item, null))
                return default(TDataSession);

            var dataSessionType = Type.GetType(item.Type);

            if(Equals(dataSessionType, null))
                return default(TDataSession);

            return (TDataSession) Activator.CreateInstance(dataSessionType);
        }

        public TDataSession CreateDataSession<TDataSession>(TDataSession defaultSession)
            where TDataSession : IDataSession
        {
            var session = CreateDataSession<TDataSession>();
            return !Equals(session, null)
                ? session
                : defaultSession;
        }
        
    }
}