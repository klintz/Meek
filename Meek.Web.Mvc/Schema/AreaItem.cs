using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Meek.Web.Mvc.Schema
{
    [Serializable]
    [XmlRoot("Area",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    public class AreaItem
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlArray("Views")]
        [XmlArrayItem("View")]
        public List<ViewItem> Views { get; set; }

        [XmlArray("PartialViews")]
        [XmlArrayItem("PartialView")]
        public List<PartialViewItem> PartialViews { get; set; }
        
    }
}
