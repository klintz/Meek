namespace Meek.Data
{
    public class DataSessionManager
    {
        public static IDataSessionFactory DataSessionFactory { get; private set; }

        public static void SetDataSessionFactory(IDataSessionFactory factory)
        {
            DataSessionFactory = factory;
        }
    }
}
