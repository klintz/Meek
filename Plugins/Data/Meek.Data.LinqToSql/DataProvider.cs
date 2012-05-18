using System.Data.Linq;

namespace Meek.Data.LinqToSql
{
    public class DataProvider : Common.DataProvider
    {
        internal DataContext DataContext { get; private set; }

        public DataProvider(DataContext context)
        {
            DataContext = context;
        }
    }
}
