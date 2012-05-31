using System;
using System.Xml.Serialization;

namespace Meek.Web.Mvc.Schema
{
    [Serializable]
    [XmlRoot("PartialView",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    public class PartialViewItem : IPartialViewConfig
    {
        public PartialViewItem()
        {
            Active = true;
        }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("File")]
        public string File { get; set; }

        [XmlElement("Themed")]
        public bool Themed { get; set; }

        [XmlElement("Active")]
        public bool Active { get; set; }
    }
}
