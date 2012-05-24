using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Meek
{
    public static class StringExtension
    {
        #region Variables
        private static MD5CryptoServiceProvider _md5;
        #endregion

        #region Contains
        /// <summary>
        /// Checks if the source string contains the specified string to check 
        /// based on the comparison contstraint
        /// </summary>
        /// <param name="source">Source String</param>
        /// <param name="toCheck">String to Check</param>
        /// <param name="comparison">StringComparison constraint</param>
        /// <returns>bool</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comparison)
        {
            return source.IndexOf(toCheck, comparison) > 0;
        }
        #endregion

        #region IsValidEmailAddress
        /// <summary>
        /// Returns true if the source string is a valid Email Address Format
        /// </summary>
        /// <param name="source">String to Check format</param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddress(this string source)
        {
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(source);
        }
        #endregion

        #region IsValidUrl
        /// <summary>
        /// Checks if the String is a valid URL format
        /// </summary>
        /// <param name="source">String to Check</param>
        /// <returns>bool</returns>
        public static bool IsValidUrl(this string source)
        {
            const string strRegex = "^(https?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                + "|" // allows either IP or domain
                + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                + "(:[0-9]{1,5})?" // port number- :80
                + "((/?)|" // a slash isn't required if there is no file name
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(source);
        }
        #endregion

        #region UrlAvailable
        /// <summary>
        /// Checks if the URL string is available
        /// </summary>
        /// <param name="source">URL string</param>
        /// <returns>bool</returns>
        public static bool UrlAvailable(this string source)
        {
            string httpUrl = source;
            if (!httpUrl.StartsWith("http://") && !httpUrl.StartsWith("https://"))
                httpUrl = "http://" + source;
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(httpUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Reverse
        /// <summary>
        /// Reverse the source string
        /// </summary>
        /// <param name="source">String to be reversed</param>
        /// <returns>string</returns>
        public static string Reverse(this string source)
        {
            char[] chars = source.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
        #endregion

        #region Reduce
        /// <summary>
        /// Reduce String to shorter preview
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="count">reduce length</param>
        /// <returns></returns>
        public static string Reduce(this string source, int count)
        {
            return Reduce(source, count, string.Empty);
        }

        /// <summary>
        /// Reduce String to shorter preview with a specified ending string
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="count">reduce length</param>
        /// <param name="endings">ending string</param>
        /// <returns>string</returns>
        public static string Reduce(this string source, int count, string endings)
        {
            endings = endings ?? string.Empty;

            if (count < endings.Length)
                throw new Exception("Failed to reduce to less then endings length.");
            int sLength = source.Length;
            int len = sLength;
            
            len += endings.Length;
            if (count > sLength)
                return source; 
            var s = source.Substring(0, sLength - len + count);
            
            s += endings;
            return s;
        }
        #endregion

        #region RemoveSpaces
        /// <summary>
        /// Removes all emtpy spaces
        /// </summary>
        /// <param name="source">source string</param>
        /// <returns>string</returns>
        public static string RemoveSpaces(this string source)
        {
            return source.Replace(" ", string.Empty);
        }
        #endregion

        #region IsNumber
        /// <summary>
        /// Checks if the specified string is a number
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="floatpoint">floating point flag</param>
        /// <returns>bool</returns>
        public static bool IsNumber(this string source, bool floatpoint)
        {
            int i;
            double d;
            string withoutWhiteSpace = source.RemoveSpaces();
            if (floatpoint)
                return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
                    Thread.CurrentThread.CurrentUICulture, out d);
            return int.TryParse(withoutWhiteSpace, out i);
        }
        #endregion

        #region IsInteger
        /// <summary>
        /// Checks if the string value is an integer
        /// </summary>
        /// <param name="source">source string</param>
        /// <returns>bool</returns>
        public static bool IsInteger(this string source)
        {
            return IsNumber(source, false);
        }
        #endregion

        #region IsNumberOnly
        /// <summary>
        /// Checks if the string contains only digits or float-point
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="floatpoint">float point flag</param>
        /// <returns>bool</returns>
        public static bool IsNumberOnly(this string source, bool floatpoint)
        {
            var s = source.Trim();
            if (s.Length == 0)
                return false;

            var res = from x in s where !char.IsDigit(x) 
                    && !(floatpoint && (x == '.' || x == ',')) 
                    select x;
            return !res.Any();
        }
        #endregion

        #region IsIntegerOnly
        /// <summary>
        /// Checks if the string contains integers only
        /// </summary>
        /// <param name="source">source string</param>
        /// <returns>bool</returns>
        public static bool IsIntegerOnly(this string source)
        {
            return IsNumberOnly(source, false);
        }
        #endregion

        #region RemoveDiacritics
        /// <summary>
        /// Removes diacritics character in a string
        /// </summary>
        /// <param name="source">string</param>
        /// <returns>string</returns>
        public static string RemoveDiacritics(this string source)
        {
            var stFormD = source.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var ch in stFormD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
        #endregion

        #region Nl2Br
        /// <summary>
        /// Replaces strings line breaks with html tag <br />
        /// </summary>
        /// <param name="source">string</param>
        /// <returns>string</returns>
        public static string Nl2Br(this string source)
        {
            return source.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }
        #endregion

        #region MD5
        /// <summary>
        /// Converts string into MD5 hash
        /// </summary>
        /// <param name="source">string</param>
        /// <returns>string</returns>
        public static string MD5(this string source)
        {
            _md5 = _md5 ?? new MD5CryptoServiceProvider();
            var newdata = Encoding.Default.GetBytes(source);
            var encrypted = _md5.ComputeHash(newdata);
            return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
        }
        #endregion
    }
}