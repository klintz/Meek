using System;
using System.Collections.Generic;
using Meek.Caching.Configuration;

namespace Meek.Caching
{
    /// <summary>
    /// Meek Default Cache Factory
    /// </summary>
    public class CacheFactory : ICacheFactory, IDisposable
    {
        #region CacheContainer
        /// <summary>
        /// Caches Container
        /// </summary>
        private Dictionary<string, ICache> CacheContainer { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Instantiate a new CacheFactory
        /// </summary>
        public CacheFactory()
        {
            CacheContainer = new Dictionary<string, ICache>();
        }
        #endregion

        #region NewCache
        /// <summary>
        /// Creates a New ICache
        /// </summary>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        private ICache NewCache(string cacheName)
        {
            var cache = new Cache(cacheName);
            CacheContainer.Add(cacheName, cache);
            return cache;
        }
        #endregion

        #region GetCache
        /// <summary>
        /// Creates or Gets a Cache Instance
        /// </summary>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public ICache GetCache(string cacheName)
        {
            return CacheContainer.ContainsKey(cacheName)
                ? CacheContainer[cacheName]
                : NewCache(cacheName);
        }
        #endregion

        #region AddVariable
        /// <summary>
        /// Adds an instance variable to the Factory
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void AddVariable(string key, string value)
        {
            
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Disposes the CacheFactory Instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                CacheContainer = null;
            }
        }
        #endregion

        #region CacheFactoryContainer
        private class CacheFactoryContainer
        {
            private ICacheFactory _factory;

            private ICacheFactory CacheFactory
            {
                get
                {
                    if(Equals(_factory, null))
                    {
                        if(!Equals(CreateEvent, null))
                        {
                            var type = Type.GetType(FactoryType);
                            _factory = CreateEvent(type);
                        }
                    }
                    return _factory;
                }
            }

            public string FactoryType { private get; set; }
            
            public Func<Type, ICacheFactory> CreateEvent;

            public ICacheFactory GetFactory()
            {
                return CacheFactory;
            }
        }
        #endregion

        #region Singleton

        #region Variables
        private static ICacheFactory _defaultCacheFactory;
        private static CacheFactoryConfigurationSection _configSection;
        #endregion

        #region Factories
        private static Dictionary<string, CacheFactoryContainer> Factories { get; set; }
        #endregion

        #region Constructor
        static CacheFactory()
        {
            Factories = new Dictionary<string, CacheFactoryContainer>();

            if(Equals(CacheFactoryConfiguration, null))
                return;
            
            foreach (CacheFactoryConfigurationElement factoryConfig in CacheFactoryConfiguration.CacheFactories)
            {
                var factoryContainer = new CacheFactoryContainer
                                           {
                                               FactoryType = factoryConfig.FactoryType,
                                               CreateEvent = GetCacheFactory
                                           };

                if (Factories.ContainsKey(factoryConfig.Name))
                    continue;

                Factories.Add(factoryConfig.Name, factoryContainer);
                if(CacheFactoryConfiguration.DefaultCacheFactory.Equals(factoryConfig.Name))
                    SetDefaultCacheFactory(factoryContainer.GetFactory());
            }
        }
        #endregion

        #region GetCacheFactory
        private static ICacheFactory GetCacheFactory(Type cacheFactoryType)
        {
            var instance = Activator.CreateInstance(cacheFactoryType);
            if (instance is ICacheFactory)
                return instance as ICacheFactory;
            return null;
        }
        #endregion

        #region Configuration
        /// <summary>
        /// Sets the configuration of the CacheFactories
        /// </summary>
        /// <param name="configuration">CacheFactoryConfigurationSection</param>
        public static void SetCacheFactoryConfiguration(CacheFactoryConfigurationSection configuration)
        {
            _configSection = configuration;
        }

        /// <summary>
        /// CacheFactory Configuration
        /// </summary>
        private static CacheFactoryConfigurationSection CacheFactoryConfiguration
        {
            get { _configSection = _configSection ?? CacheFactoryConfigurationSection.Default;
                return _configSection;
            }
        }
        #endregion

        #region Default
        /// <summary>
        /// Gets the Default CacheFactory Instance
        /// </summary>
        public static ICacheFactory Default
        {
            get 
            { 
                _defaultCacheFactory = _defaultCacheFactory ?? new CacheFactory();
                return _defaultCacheFactory; 
            }
        }
        #endregion

        #region SetDefaultCacheFactory
        /// <summary>
        /// Sets the Default CacheFactory Instance
        /// </summary>
        /// <param name="cacheFactory">ICacheFactory Instance</param>
        public static void SetDefaultCacheFactory(ICacheFactory cacheFactory)
        {
            if(Equals(cacheFactory, null))
                throw new ArgumentNullException("cacheFactory");
            _defaultCacheFactory = cacheFactory;
        }
        #endregion

        #region GetFactory
        /// <summary>
        /// Returns an instance of a named CacheFactory
        /// </summary>
        /// <param name="name">name of the CacheFactory</param>
        /// <returns>ICacheFactory</returns>
        public static ICacheFactory GetFactory(string name)
        {
            return (Factories.ContainsKey(name))
                ? Factories[name].GetFactory()
                : default(ICacheFactory);
        }
        #endregion

        #endregion
    }
}
