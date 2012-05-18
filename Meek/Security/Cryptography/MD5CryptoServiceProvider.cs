using System;
using System.IO;
using System.Security.Cryptography;

namespace Meek.Security.Cryptography
{
    /// <summary>
    /// MD5 Crypto Service Provider
    /// </summary>
    public class MD5CryptoServiceProvider
    {
        private byte[] _salt;
        private int _saltSize = 128;

        public bool SaltHash { get; set; }

        /// <summary>
        /// Salt Size
        /// </summary>
        public int SaltSize
        {
            get
            {
                return _saltSize;
            }
            set
            {
                _saltSize = value;
            }
        }

        /// <summary>
        /// Salt
        /// </summary>
        public byte[] Salt
        {
            get
            {
                if (Equals(_salt, null))
                {
                    _salt = new byte[SaltSize];
                    var rng = new RNGCryptoServiceProvider();
                    rng.GetNonZeroBytes(_salt);
                }
                return _salt;
            }
            set
            {
                _salt = value;
            }
        }


        /// <summary>
        /// Compute Hash
        /// </summary>
        /// <param name="data">byte[] to hash</param>
        /// <returns>byte[]</returns>
        public byte[] ComputeHash(byte[] data)
        {
            if (Equals(data, null))
                throw new ArgumentNullException("data");

            if (SaltHash)
                return ComputeHash(data, Salt);

            var provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return provider.ComputeHash(data);
        }

        /// <summary>
        /// Compute Hash with a specified salt
        /// </summary>
        /// <param name="data">byte[] to hash</param>
        /// <param name="salt">salt</param>
        /// <returns>byte[]</returns>
        public byte[] ComputeHash(byte[] data, byte[] salt)
        {
            if (Equals(data, null))
                throw new ArgumentNullException("data");

            if (Equals(salt, null))
                throw new ArgumentNullException("salt");

            var dataPlusSalt = new byte[data.Length + salt.Length];
            Array.Copy(data, dataPlusSalt, data.Length);
            Array.Copy(salt, 0, dataPlusSalt, data.Length, salt.Length);
            var provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return provider.ComputeHash(dataPlusSalt);
        }

        /// <summary>
        /// Compute Hash from a specified stream
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns>byte[]</returns>
        public byte[] ComputeHash(Stream stream)
        {
            if (Equals(stream, null))
                throw new ArgumentNullException("stream");

            if (SaltHash)
                return ComputeHash(stream, Salt);

            var provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return provider.ComputeHash(stream);
        }

        /// <summary>
        /// Compute Hash from a specified stream and a salt
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="salt">salt</param>
        /// <returns>byte[]</returns>
        public byte[] ComputeHash(Stream stream, byte[] salt)
        {
            if (Equals(stream, null))
                throw new ArgumentNullException("stream");

            var data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length - 1);

            return ComputeHash(data, salt);
        }
    }
}
