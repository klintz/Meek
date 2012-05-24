using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meek.Caching;
using Moq;
using NUnit.Framework;

namespace Test.Meek.Caching
{
    [TestFixture]
    public class TestCacheFactory
    {
        [Test]
        public void TestDefaultCacheFactoryInstance()
        {
            var factory = CacheFactory.Default;
            Assert.IsTrue(factory != null);
        }

        [Test]
        public void TestGetCacheFromMeekCacheFactory()
        {
            var cacheId = Guid.NewGuid().ToString();
            var factory = new CacheFactory();
            var expected = factory.GetCache(cacheId);
            var result = factory.GetCache(cacheId);

            Assert.IsTrue(result == expected);
        }

        [Test]
        public void TestGetCacheFromMeekCacheFactoryThrowsArgumentNullException()
        {
            try
            {
                var factory = new CacheFactory();
                var cache = factory.GetCache(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [Test]
        public void TestRemoveCacheFromMeekCacheFactory()
        {
            var cacheId = Guid.NewGuid().ToString();
            var factory = new CacheFactory();
            var expected = factory.GetCache(cacheId);
            factory.RemoveCache(cacheId);
            var result = factory.GetCache(cacheId);
            Assert.IsFalse(expected == result);
        }

        [Test]
        public void TestRemoveCacheFromMeekCacheFactoryThrowsArgumentNullException()
        {
            try
            {
                var factory = new CacheFactory();
                factory.RemoveCache(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);    
            }
        }

        [Test]
        public void TestGetCacheFromDefault()
        {
            var cacheId = Guid.NewGuid().ToString();
            var expected = CacheFactory.Default.GetCache(cacheId);
            var result = CacheFactory.Default.GetCache(cacheId);
            Assert.IsTrue(expected == result);
        }

        [Test]
        public void TestDefaultCacheFactoryDispose()
        {
            try
            {
                var factory = new CacheFactory();
                factory.Dispose();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void TestSetDefaultCacheFactoryThrowsArgumentNullException()
        {
            try
            {
                CacheFactory.SetDefaultCacheFactory(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [Test]
        public void TestSetDefaultCacheFactory()
        {
            var factory = new Mock<ICacheFactory>();
            CacheFactory.SetDefaultCacheFactory(factory.Object);
            Assert.IsTrue(CacheFactory.Default == factory.Object);
        }

       

        [Test]
        public void TestGetCache()
        {
            var factory = new Mock<ICacheFactory>();
            var expected = new Mock<ICache>();
            factory.Setup(f => f.GetCache("cache1")).Returns(expected.Object);
            
            CacheFactory.SetDefaultCacheFactory(factory.Object);
            var result = CacheFactory.Default.GetCache("cache1");
            Assert.IsTrue(result == expected.Object);
        }

        [Test]
        public void TestGetFactoryFromConfigFile()
        {
            var factory = CacheFactory.GetFactory("Meek.Caching.CacheFactory");
            Assert.IsTrue(factory != null);
        }
    }
}
