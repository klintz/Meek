using System;
using System.Data;
using System.Data.Objects;


namespace Meek.Data.EntityFramework
{
    public class DataProvider : Common.DataProvider, IDisposable
    {
        private IDbTransaction Transaction { get; set; }

        internal ObjectContext DataContext { get; private set; }

        public DataProvider(string connectionString)
        {
            DataContext = new ObjectContext(connectionString);
        }

        public DataProvider(ObjectContext context)
        {
            DataContext = context;
        }

        public override void BeginTransaction()
        {
            Transaction = DataContext.Connection.BeginTransaction();
        }

        public override void CommitTransaction()
        {
            Transaction.Commit();
        }

        public override void RollbackTransaction()
        {
            Transaction.Rollback();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                DataContext.Dispose();
            }
        }
    }
}
