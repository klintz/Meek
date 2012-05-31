using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Meek.Web.Mvc.Schema;
using NUnit.Framework;

namespace Test.Meek.Web.Mvc.Schema
{
    [TestFixture]
    public class TestAreaItem
    {
        [Test]
        public void TestDeserialize()
        {
            const string xmlSource = @"..\..\Schema\TestArea.xml";
            Stream stream = null;
            try
            {
                var serializer = new XmlSerializer(typeof(AreaItem));
                stream = new FileStream(xmlSource, FileMode.Open);
                var area = serializer.Deserialize(stream) as AreaItem;
                Assert.IsNotNull(area);
                Assert.IsTrue(area.PartialViews.Count == 1);
                Assert.IsTrue(area.Views.Count == 1);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
    }
}
