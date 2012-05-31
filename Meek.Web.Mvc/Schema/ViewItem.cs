﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Meek.Web.Mvc.Schema
{
    [Serializable]
    [XmlRoot("ViewItem",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    class ViewItem : IViewConfig
    {
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
