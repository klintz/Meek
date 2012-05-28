using System;

namespace Meek.Security.Cryptography
{
    public class RSACryptoServiceProvider : IDisposable
    {
        /// <summary>
        /// Key
        /// </summary>
        public byte[] Key
        {
            get { return Provider.ExportCspBlob(true); }
            set { Provider.ImportCspBlob(value); }
        }

        /// <summary>
        /// Public Key
        /// </summary>
        public byte[] PublicKey
        {
            get { return Provider.ExportCspBlob(false); }
        }

        private System.Security.Cryptography.RSACryptoServiceProvider _provider;

        /// <summary>
        /// Key Size
        /// </summary>
        public int KeySize { get; set; }

        protected System.Security.Cryptography.RSACryptoServiceProvider Provider
        {
            get
            {
                _provider = _provider ?? new System.Security.Cryptography.RSACryptoServiceProvider(KeySize);
                return _provider;
            }
        }

        /// <summary>
        /// Initialize an RSACryptoServiceProvider instance
        /// </summary>
        public RSACryptoServiceProvider()
            :this(1024)
        {}

        /// <summary>
        /// Initialize an RSACryptoServiceProvider instance with a specified key size
        /// </summary>
        /// <param name="keySize">int</param>
        public RSACryptoServiceProvider(int keySize)
        {
            KeySize = keySize;
        }

        /// <summary>
        /// Encrypts a value
        /// </summary>
        /// <param name="value">The data to be encrypted. </param>
        /// <returns>byte[]</returns>
        public byte[] Encrypt(byte[] value)
        {
            return Encrypt(value, false);
        }

        /// <summary>
        /// Encrypts a value
        /// </summary>
        /// <param name="value">The data to be encrypted.</param>
        /// <param name="f0AEP">
        /// true to perform direct RSA encryption using OAEP padding 
        /// (only available on a computer running Microsoft Windows XP or later); 
        /// otherwise, false to use PKCS#1 v1.5 padding. 
        /// </param>
        /// <returns>bute[]</returns>
        public byte[] Encrypt(byte[] value, bool f0AEP)
        {
            return Provider.Encrypt(value, f0AEP);
        }

        /// <summary>
        /// Decrypts an encrypted value
        /// </summary>
        /// <param name="value">The data to be decrypted.</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] value)
        {
            return Decrypt(value, false);
        }

        /// <summary>
        /// Decrypts an encrypted value
        /// </summary>
        /// <param name="value">The data to be decrypted.</param>
        /// <param name="f0AEP">
        /// true to perform direct RSA encryption using OAEP padding 
        /// (only available on a computer running Microsoft Windows XP or later); 
        /// otherwise, false to use PKCS#1 v1.5 padding. 
        /// </param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] value, bool f0AEP)
        {
            return Provider.Decrypt(value, f0AEP);
        }

        /// <summary>
        /// Disposes the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                Provider.Dispose();       
            }
        }
    }
}
