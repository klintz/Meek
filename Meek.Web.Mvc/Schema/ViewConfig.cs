using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Meek.Web.Mvc.Schema
{
    [Serializable]
    [XmlRoot("ViewConfig",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    public class ViewConfig
    {
        [XmlArray("Areas")]
        [XmlArrayItem("Area")]
        public List<AreaItem> Areas { get; set; }

        [XmlArray("Views")]
        [XmlArrayItem("View")]
        public List<ViewItem> Views { get; set; }

        [XmlArray("PartialViews")]
        [XmlArrayItem("PartialView")]
        public List<PartialViewItem> PartialViews { get; set; }
    }
}
