using System;
using System.Xml.Serialization;

namespace Meek.Data.Extension.Schema
{
    
    [Serializable]
    [XmlRoot("DataSession",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    public class DataSessionItem
    {
        public DataSessionItem()
        {
            IsActive = true;
        }

        [XmlElement("Base")]
        public string Base { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Active")]
        public bool IsActive { get; set; }
    }
}
