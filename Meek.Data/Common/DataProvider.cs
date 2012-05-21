namespace Meek.Data.Common
{
    public abstract class DataProvider : IDataProvider
    {
        public abstract void BeginTransaction();

        public abstract void CommitTransaction();

        public abstract void RollbackTransaction();
    }
}
