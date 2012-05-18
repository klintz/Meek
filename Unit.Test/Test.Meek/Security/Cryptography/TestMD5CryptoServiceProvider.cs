using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Meek.Security.Cryptography;

namespace Test.Meek.Security.Cryptography
{
    [TestFixture]
    public class TestMD5CryptoServiceProvider
    {
        [Test]
        public void TestConstructor()
        {
            var crypto = new MD5CryptoServiceProvider();
            Assert.IsTrue(!Equals(crypto, null));
        }

        [Test]
        public void CryptoCreateHash()
        {
            var crypto = new MD5CryptoServiceProvider();
            crypto.SaltSize = 64;

            const string password = "password!";

            var encoding = new UTF8Encoding();
            var passwordBytes = encoding.GetBytes(password);

            crypto.SaltHash = true;

            var hash = crypto.ComputeHash(passwordBytes);
            var salt = crypto.Salt;

            crypto.Salt = salt;
            var newHash = crypto.ComputeHash(passwordBytes);
            
            Assert.IsTrue(hash.SequenceEqual(newHash));
        }
    }
}
