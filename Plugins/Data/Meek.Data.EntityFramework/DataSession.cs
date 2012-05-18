using System.Data.Objects;

namespace Meek.Data.EntityFramework
{
    public abstract class DataSession : Common.DataSession
    {
        private DataProvider _dataProvider;

        private DataProvider DataProvider
        {
            get { _dataProvider = (DataProvider) Provider;
                return _dataProvider;
            }
        }
            
        protected virtual ObjectContext DataContext
        {
            get
            {
                return (!Equals(DataProvider, null))
                           ? DataProvider.DataContext
                           : null;
            }
        }

        protected DataSession(DataProvider provider)
             :base(provider)
        {
             
        }
    }
}