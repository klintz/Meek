namespace Meek.Data.Extension
{
    public class DataSessionFactory : IDataSessionFactory
    {
        public TDataSession CreateDataSession<TDataSession>()
           where TDataSession : IDataSession
        {
            return default(TDataSession);
        }

        public TDataSession CreateDataSession<TDataSession>(TDataSession defaultSession)
            where TDataSession : IDataSession
        {
            return defaultSession;
        }
    }
}