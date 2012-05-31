using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Meek.Web.Mvc.Schema;

namespace Meek.Web.Mvc
{
    
    public class ViewConfigSource : IViewConfigSource
    {
        private ViewConfig Config { get; set; }

        public static ViewConfigSource Create(string xmlSource)
        {
            if (!File.Exists(xmlSource))
                throw new FileNotFoundException(xmlSource);
            Stream stream = null;
            try
            {
                var serializer = new XmlSerializer(typeof(ViewConfig));
                stream = new FileStream(xmlSource, FileMode.Open);
                var result = serializer.Deserialize(stream) as ViewConfig;

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

        

    }
}