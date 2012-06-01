using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Meek.Web.Mvc.Schema;

namespace Meek.Web.Mvc
{
    
    public class ViewConfigSource : IViewConfigSource
    {
        private ViewConfigSchema _config;

        private ViewConfigSchema Config
        {
            get 
            { 
                _config = _config ?? new ViewConfigSchema();
                return _config; 
            }
            set { _config = value; }
        }

        public static ViewConfigSource Create(string xmlSource)
        {
            if (!File.Exists(xmlSource))
                throw new FileNotFoundException(xmlSource);
            Stream stream = null;
            try
            {
                var serializer = new XmlSerializer(typeof(ViewConfigSchema));
                stream = new FileStream(xmlSource, FileMode.Open);
                var result = serializer.Deserialize(stream) as ViewConfigSchema;

                if(result == null)
                    throw new Exception("Unable to create ViewConfigSource out of the xml file.");

                var configSource = new ViewConfigSource {Config = result};
                return configSource;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        internal ViewConfigSource()
        {
            
        }

        public IViewConfig GetViewConfig(string viewName)
        {
            return Config.Views.SingleOrDefault(x => x.Name == viewName);
        }

        public IPartialViewConfig GetPartialViewConfig(string partialViewName)
        {
            return Config.PartialViews.SingleOrDefault(x => x.Name == partialViewName);
        }

        public IMasterConfig GetMasterConfig(string masterName)
        {
            return Config.Masters.SingleOrDefault(x => x.Name == masterName);
        }

        public IViewConfigSource GetAreaConfig(string areaName)
        {
            if (string.IsNullOrEmpty(areaName))
                return default(IViewConfigSource);
            var source = Config.Areas.SingleOrDefault(x => x.Name == areaName);
            var viewConfigSource = new ViewConfigSource {Config = source};
            return viewConfigSource;
        }
    }
}