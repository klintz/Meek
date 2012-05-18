using System.Configuration;

namespace Meek.Caching.Configuration
{
    public class CacheFactoryConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("FactoryType", IsRequired = true)]
        public string FactoryType
        {
            get { return (string)this["FactoryType"]; }
            set { this["FactoryType"] = value; }
        }

        [
        ConfigurationProperty("VariableElementCollection", IsDefaultCollection = false),
        ConfigurationCollection(typeof(CacheFactoryVariableElementCollection), AddItemName = "addVariable", ClearItemsName = "clearVariables", RemoveItemName = "removeVariable")
        ]
        public CacheFactoryVariableElementCollection VariableElementCollection
        {
            get
            {
                return this["VariableElementCollection"] as CacheFactoryVariableElementCollection;
            }
        }
    }
}
