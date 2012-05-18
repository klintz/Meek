using System.Data.Objects;


namespace Meek.Data.EntityFramework
{
    public class DataProvider : Common.DataProvider
    {
        internal ObjectContext DataContext { get; private set; }

        public DataProvider(string connectionString)
        {
            DataContext = new ObjectContext(connectionString);
        }

        public DataProvider(ObjectContext context)
        {
            DataContext = context;
        }
    }
}
