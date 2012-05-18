using System;
using System.Configuration;

namespace Meek.Caching.Configuration
{
    public class CacheFactoryConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("DefaultCacheFactory")]
        public string DefaultCacheFactory
        {
            get
            {
                if (Equals(this["DefaultCacheFactory"], null))
                    throw new Exception("DefaultCacheFactory not defined.");
                return (string)this["DefaultCacheFactory"];
            }
        }

        [ConfigurationProperty("CacheFactories", IsDefaultCollection = false),
        ConfigurationCollection(typeof(CacheConfigurationElementCollection), 
            AddItemName = "CacheFactory", 
            ClearItemsName = "ClearCacheFactories", 
            RemoveItemName = "RemoveCacheFactory")]
        public CacheConfigurationElementCollection CacheFactories
        {
            get { return this["CacheFactories"] as CacheConfigurationElementCollection; }
        }

        internal static CacheFactoryConfigurationSection Default
        {
            get
            {
                var section = ConfigurationManager.GetSection("Meek.CacheFactory");
                if (Equals(section, null))
                    return null;
                
                if(section is CacheFactoryConfigurationSection)
                    return section as CacheFactoryConfigurationSection;

                return null;

            }
        }
    }
}
