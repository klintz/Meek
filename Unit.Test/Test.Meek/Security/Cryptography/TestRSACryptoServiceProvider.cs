using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Meek.Security.Cryptography;
using NUnit.Framework;


namespace Test.Meek.Security.Cryptography
{
    [TestFixture]
    public class TestRSACryptoServiceProvider
    {
        [Test]
        public void TestConstructor()
        {
            var crypto = new RSACryptoServiceProvider();
            Assert.IsTrue(crypto.KeySize == 1024);

            var crypto2 = new RSACryptoServiceProvider(2064);
            Assert.IsTrue(crypto2.KeySize == 2064);
        }

        [Test]
        public void TestEncryptDecrypt()
        {
            const string expected = "password";
            var encoding = new UnicodeEncoding();

            var crypto = new RSACryptoServiceProvider();
            var expectedBytes = encoding.GetBytes(expected);
            var resultBytes = crypto.Encrypt(expectedBytes);

            resultBytes = crypto.Decrypt(resultBytes);
            
            var result = encoding.GetString(resultBytes);

            Assert.IsTrue(expected == result);
        }

        [Test]
        public void TestEncryptDecryptWithKey()
        {
            var string1 = Guid.NewGuid().ToString();
            var string2 = Guid.NewGuid().ToString();
            var string3 = Guid.NewGuid().ToString();
            var encoding = new UnicodeEncoding();
            
            var crypto = new RSACryptoServiceProvider();
            
            var privateKey = crypto.Key;
            var publicKey = crypto.PublicKey;
            
            crypto.Dispose();

            var encryptor = new RSACryptoServiceProvider();
            encryptor.Key = publicKey;

            var encrypted1 = encryptor.Encrypt(encoding.GetBytes(string1));
            var encrypted2 = encryptor.Encrypt(encoding.GetBytes(string2));
            var encrypted3 = encryptor.Encrypt(encoding.GetBytes(string3));

            var decryptor = new RSACryptoServiceProvider();
            decryptor.Key = privateKey;

            var decrypted1 = decryptor.Decrypt(encrypted1);
            var decrypted2 = decryptor.Decrypt(encrypted2);
            var decrypted3 = decryptor.Decrypt(encrypted3);

            var rresult1 = encoding.GetString(decrypted1);
            var rresult2 = encoding.GetString(decrypted2);
            var rresult3 = encoding.GetString(decrypted3);

            Assert.IsTrue(string1 == rresult1);
            Assert.IsTrue(string2 == rresult2);
            Assert.IsTrue(string3 == rresult3);
        }
    }
}

