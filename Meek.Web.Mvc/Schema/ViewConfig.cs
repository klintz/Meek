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
        private List<AreaItem> _areas;
        private List<ViewItem> _views;
        private List<PartialViewItem> _partials;

        [XmlArray("Areas")]
        [XmlArrayItem("Area")]
        public List<AreaItem> Areas 
        {
            get 
            { 
                _areas = _areas ?? new List<AreaItem>();
                return _areas;
            }
            set 
            {
                _areas = value;
            }
        }

        [XmlArray("Views")]
        [XmlArrayItem("View")]
        public List<ViewItem> Views 
        {
            get
            {
                _views = _views ?? new List<ViewItem>();
                return _views;
            }
            set
            {
                _views = value;
            }
        }

        [XmlArray("PartialViews")]
        [XmlArrayItem("PartialView")]
        public List<PartialViewItem> PartialViews 
        {
            get
            {
                _partials = _partials ?? new List<PartialViewItem>();
                return _partials;
            }
            set
            {
                _partials = value;
            }
        }
    }
}
