using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MeekActivator = Meek.Activator;


namespace Test.Meek
{
    public class MessageEntity
    {
        public string Message { get; set; }

        public string Sender { get; set; }
        
    }

    public class ParameterizedEntity
    {
        public ParameterizedEntity(string msg)
        {
            
        }
    }

    [TestFixture]
    public class TestActivator
    {

        [Test]
        public void TestCreateInstance()
        {
            var typeOfMessageEntity = typeof (MessageEntity);

            var instance = MeekActivator.CreateInstance(typeOfMessageEntity);

            var otherInstance = MeekActivator.CreateInstance<MessageEntity>();
            
            Assert.IsTrue(!Equals(instance, null));
            Assert.IsTrue(!Equals(otherInstance, null));
        }

        [Test]
        public void TestCreateInstanceTypeNull()
        {
            try
            {
                MeekActivator.CreateInstance(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [Test]
        public void TestCreateInstanceParameterizedConstructor()
        {
            try
            {
                MeekActivator.CreateInstance(typeof(ParameterizedEntity));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("unable to find a parameterless constructor of the type."));
            }
        }
        
    }

}
