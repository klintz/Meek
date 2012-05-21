namespace Meek.Data
{
    public interface IDataProvider
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
