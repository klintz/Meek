namespace Meek.Data
{
    public interface IDataSession
    {
        IDataProvider Provider { get; set; }

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}
