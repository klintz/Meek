namespace Meek.Data
{
    public interface IDataSessionFactory
    {
        TDataSession CreateDataSession<TDataSession>()
            where TDataSession : IDataSession;

        TDataSession CreateDataSession<TDataSession>(TDataSession defaultSession)
            where TDataSession : IDataSession;
    }
}
