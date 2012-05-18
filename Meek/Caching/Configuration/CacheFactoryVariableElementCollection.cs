using System;
using System.Configuration;


namespace Meek.Caching.Configuration
{
    public class CacheFactoryVariableElementCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as CacheFactoryVariableElement;
            if (Equals(configElement, null))
                throw new Exception("Unable to cast System.Configuration.ConfigurationElement into Meek.Caching.Configuration.CacheFactoryVariableElement");
            return configElement.Key;
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
            return new CacheFactoryVariableElement();
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Add(CacheFactoryVariableElement element)
        {
            BaseAdd(element);
        }

        public void Remove(CacheFactoryVariableElement element)
        {
            BaseRemove(element.Key);
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
