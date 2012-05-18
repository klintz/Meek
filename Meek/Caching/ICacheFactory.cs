namespace Meek.Caching
{
    /// <summary>
    /// Interface for CacheFactory
    /// </summary>
    public interface ICacheFactory
    {
        /// <summary>
        /// Creates or Gets a Cache Instance
        /// </summary>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        ICache GetCache(string cacheName);
        
        /// <summary>
        /// Adds an instance variable to the Factory
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        void AddVariable(string key, string value);
    }
}