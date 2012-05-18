namespace Meek.Data
{
    public interface IDataProviderFactory
    {
        IDataProvider CreateProvider();

        IDataProvider CreateProvider(string name);
        
    }
}