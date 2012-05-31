using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Meek.Web.Mvc;
using Meek.Web.Mvc.Schema;
using NUnit.Framework;

namespace Test.Meek.Web.Mvc.Schema
{
    [TestFixture]
    public class TestConfigViewSource
    {
        [Test]
        public void TestCreate()
        {
            const string xmlSource = @"..\..\Schema\ViewConfig.xml";
            var configSource = ViewConfigSource.Create(xmlSource);

            Assert.IsNotNull(configSource);

            var view = configSource.GetViewConfig("TestView");
            Assert.IsNotNull(view);
            Assert.IsTrue(view.Name == "TestView");

            var partial = configSource.GetPartialViewConfig("TestView");
            Assert.IsNotNull(partial);
            Assert.IsTrue(partial.Name == "TestView");

        }
    }
}
