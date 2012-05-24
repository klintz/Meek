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
        /// <param name="cacheName">string</param>
        /// <returns>ICache</returns>
        ICache GetCache(string cacheName);

        /// <summary>
        /// Removes a Cache in the factory specified by the cache name
        /// </summary>
        /// <param name="cacheName">string</param>
        void RemoveCache(string cacheName);

        /// <summary>
        /// Adds an instance variable to the Factory
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        void AddVariable(string key, string value);
    }
}