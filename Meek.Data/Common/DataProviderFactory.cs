namespace Meek.Data.Common
{
    public abstract class DataProviderFactory : IDataProviderFactory
    {
        public virtual IDataProvider CreateProvider()
        {
            return CreateDefaultProvider();
        }

        protected abstract IDataProvider CreateDefaultProvider();

        public abstract IDataProvider CreateProvider(string name);
    }
}