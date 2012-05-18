using System;
using System.Configuration;


namespace Meek.Caching.Configuration
{
    public class CacheConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as CacheFactoryConfigurationElement;
            if (Equals(configElement, null)) 
                throw new Exception("Unable to cast System.Configuration.ConfigurationElement into Meek.Caching.Configuration.CacheFactoryConfigurationElement");
            return configElement.Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CacheFactoryConfigurationElement();
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Add(CacheFactoryConfigurationElement element)
        {
            BaseAdd(element);
        }

        public void Remove(CacheFactoryConfigurationElement element)
        {
            BaseRemove(element.Name);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
    }
}
