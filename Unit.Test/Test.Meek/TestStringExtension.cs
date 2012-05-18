using System;
using NUnit.Framework;
using Meek;

namespace Test.Meek
{
    [TestFixture]
    public class TestStringExtension
    {
        [Test]
        public void TestContains()
        {
            const string str = "aaaBBBccc";
            Assert.IsTrue(str.Contains("bbb", StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void TestIsValidEmailAddress()
        {
            Assert.IsTrue("michael.dcuesta@gmail.com".IsValidEmailAddress()
                          && !"michael".IsValidEmailAddress());
        }

        [Test]
        public void TestIsValidUrl()
        {
            Assert.IsTrue("http://www.domain.com".IsValidUrl());
            Assert.IsTrue("https://www.domain.com/#some_anchor".IsValidUrl());
            Assert.IsTrue("https://localhost".IsValidUrl());
            Assert.IsTrue("http://www.domain.co.net/signs-banners.jpg".IsValidUrl());
            Assert.IsTrue(("http://aa-bbbb.cc.bla.com:80800/test/" +
                          "test/test.aspx?dd=dd&id=dki").IsValidUrl());
            Assert.IsFalse("http:wwwgooglecom".IsValidUrl());
            Assert.IsFalse("http://www.go ogle.com".IsValidUrl());
        }

        [Test]
        public void TestUrlAvailable()
        {
            Assert.IsTrue("http://www.google.com".UrlAvailable());
            Assert.IsTrue("www.google.com".UrlAvailable());
            Assert.IsFalse("www.vahnpaper.com".UrlAvailable());
        }
        
        [Test]
        public void TestReverse()
        {
            Assert.IsTrue("abc".Reverse() == "cba");
        }

        [Test]
        public void TestReduce()
        {
            Assert.IsTrue("abcdefg".Reduce(3) == "abc");
            Assert.IsTrue("abcdefg".Reduce(4, "...") == "a...");
            Assert.IsTrue("abcdefg".Reduce(10) == "abcdefg");
            try
            {
                "abc".Reduce(2, "......");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(Equals(ex.Message, "Failed to reduce to less then endings length."));
            }
        }

        [Test]
        public void TestRemoveSpaces()
        {
            Assert.IsTrue(" ".RemoveSpaces() == string.Empty);
        }

        [Test]
        public void TestIsNumber()
        {
            Assert.IsFalse("a".IsNumber(true));
            Assert.IsFalse("a1".IsNumber(true));
            Assert.IsTrue("1".IsNumber(false));
            Assert.IsTrue(" 2".IsNumber(false));
            Assert.IsTrue("2.2".IsNumber(true));
            Assert.IsTrue(" 2.2".IsNumber(true));            
        }

        [Test]
        public void TestIsInteger()
        {
            Assert.IsTrue("1".IsInteger());
            Assert.IsTrue(" 1".IsInteger());
            Assert.IsFalse("a".IsInteger());
            Assert.IsFalse("a1".IsInteger());
        }


        [Test]
        public void TestIsNumberOnly()
        {
            Assert.IsFalse("a".IsNumberOnly(true));
            Assert.IsFalse("a1".IsNumberOnly(true));
            Assert.IsTrue("1".IsNumberOnly(false));
            Assert.IsFalse("2 2".IsNumberOnly(false));
            Assert.IsTrue("2.2".IsNumberOnly(true));
            Assert.IsFalse("2. 2".IsNumberOnly(true));  
            Assert.IsFalse(string.Empty.IsNumberOnly(true));
        }

        [Test]
        public void TestIsIntegerOnly()
        {
            Assert.IsTrue("1".IsIntegerOnly());
            Assert.IsFalse("1 5".IsIntegerOnly());
            Assert.IsFalse("a".IsIntegerOnly());
            Assert.IsFalse("a1".IsIntegerOnly());
        }

        [Test]
        public void TestRemoveDiacritics()
        {
            const string input = "Příliš žluťoučký kůň úpěl ďábelské ódy.";
            const string expected = "Prilis zlutoucky kun upel dabelske ody.";
            string actual = input.RemoveDiacritics();
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Nl2BrTest()
        {
            var input = "yellow dog" + Environment.NewLine + "black cat";
            const string expected = "yellow dog<br />black cat";
            string actual = input.Nl2Br();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Md5Test()
        {
            const string input = "The quick brown fox jumps over the lazy dog";
            const string expected = "9e107d9d372bb6826bd81d3542a419d6";
            string actual = input.MD5();
            Assert.AreEqual(expected, actual);
        }
    }
}
