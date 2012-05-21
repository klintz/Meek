using System;
using System.Data;
using System.Data.Linq;

namespace Meek.Data.LinqToSql
{
    public class DataProvider : Common.DataProvider, IDisposable
    {
        private IDbTransaction Transaction { get; set; }

        internal DataContext DataContext { get; private set; }

        public DataProvider(DataContext context)
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
            if (disposing)
            {
                DataContext.Dispose();
            }
        }
    }
}
