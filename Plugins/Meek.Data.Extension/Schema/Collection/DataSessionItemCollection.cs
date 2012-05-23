using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Meek.Data.Extension.Schema.Collection
{
    [XmlRoot("DataSessions",
        Namespace = "http://www.meek-framework.com/",
        IsNullable = true)]
    public class DataSessionItemCollection : List<DataSessionItem>
    {
        public static DataSessionItemCollection GetCollection(string xmlPath)
        {
            if (!File.Exists(xmlPath))
                throw new FileNotFoundException(xmlPath);

            Stream stream = null;
            try
            {
                var serializer = new XmlSerializer(typeof(DataSessionItemCollection));
                stream = new FileStream(xmlPath, FileMode.Open);
                var list = serializer.Deserialize(stream) as DataSessionItemCollection;
                return list;
            }
            finally
            {
                if (!Equals(stream, null))
                    stream.Close();
            }
        }
    }
}
