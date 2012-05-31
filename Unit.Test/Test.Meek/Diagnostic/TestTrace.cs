using System;
using Meek.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Test.Meek.Diagnostic
{
    [TestFixture]
    public class TestTrace
    {
        #region Write
        [Test]
        public void TestDebugWriteString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            Trace.Write("hello.world");
            logger.Verify(l => l.Write("hello.world"));
        }
        [Test]
        public void TestDebugWriteObject()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var expected = new { Name = "Gwapo", Age = 3 };
            Trace.Write(expected);
            logger.Verify(l => l.Write(expected));

        }

        [Test]
        public void TestDebugWriteObjectLogEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var expected = new { Name = "Gwapo", Age = 3 };
            LogTypeEnum logType = LogTypeEnum.Critical;
            Trace.Write(expected, logType);
            logger.Verify(l => l.Write(expected, logType));

        }
        [Test]
        public void TestDebugWriteObjectCategory()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var expected = new { Name = "Gwapo", Age = 3 };
            var result = new { Name = "Gwapo", Age = 3 };
            string category = "category 1";
            Trace.Write(expected, category);
            logger.Verify(l => l.Write(result, category));

        }
        [Test]
        public void TestDebugWriteMsgeCategory()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            string category = "category 1";
            string msge = "helloword";
            Trace.Write(msge, category);
            logger.Verify(l => l.Write(msge, category));

        }
        [Test]
        public void TestDebugWriteMsgeLogEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            string msge = "helloword";
            LogTypeEnum logType = LogTypeEnum.Info;
            Trace.Write(msge, logType);
            logger.Verify(l => l.Write(msge, logType));

        }

        [Test]
        public void TestDebugWriteException()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            string msge = "helloword";
            var ex = new Exception(msge);
            Trace.Write(ex);
            logger.Verify(l => l.Write(ex));

        }
        #endregion Write

        #region WriteIf
        [Test]
        public void TestDebugWriteIfBoolObject()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var ex = new Exception();
            Trace.WriteIf(true, ex);
            logger.Verify(l => l.WriteIf(true, ex));

        }
        [Test]
        public void TestDebugWriteIfBoolObjectString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var ex = new Exception();
            string helloWorld = "helloWorld";
            Trace.WriteIf(true, ex, helloWorld);
            logger.Verify(l => l.WriteIf(true, ex, helloWorld));

        }
        [Test]
        public void TestDebugWriteIfBoolString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            string helloWorld = "helloWorld";
            Trace.WriteIf(true, helloWorld);
            logger.Verify(l => l.WriteIf(true, helloWorld));

        }

        [Test]
        public void TestDebugWriteIfBoolStringString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            string helloWorld = "helloWorld";
            string category1 = "category1";
            Trace.WriteIf(true, helloWorld, category1);
            logger.Verify(l => l.WriteIf(true, helloWorld, category1));

        }

        [Test]
        public void TestDebugWriteIfBoolObjectLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            string helloWorld = "helloWorld";
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            Trace.WriteIf(true, helloWorld, logTypeCritical);
            logger.Verify(l => l.WriteIf(true, helloWorld, logTypeCritical));

        }

        [Test]
        public void TestDebugWriteIfBoolStringLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            string helloWorld = "helloWorld";
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            Trace.WriteIf(true, helloWorld, logTypeCritical);
            logger.Verify(l => l.WriteIf(true, helloWorld, logTypeCritical));

        }

        [Test]
        public void TestDebugWriteIfBoolException()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var ex = new Exception();
            Trace.WriteIf(true, ex);
            logger.Verify(l => l.WriteIf(true, ex));

        }
        #endregion WriteIf

        #region WriteLine
        [Test]
        public void TestDebugWriteLineException()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var ex = new Exception();
            Trace.WriteLine(ex);
            logger.Verify(l => l.WriteLine(ex));

        }
        [Test]
        public void TestDebugWriteLineObject()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var objValue = new Exception();
            Trace.WriteLine(objValue);
            logger.Verify(l => l.WriteLine(objValue));

        }

        [Test]
        public void TestDebugWriteLineObjectLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var objValue = new Exception();
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            Trace.WriteLine(objValue,logTypeInfo);
            logger.Verify(l => l.WriteLine(objValue, logTypeInfo));

        }
        [Test]
        public void TestDebugWriteLineStringParamsObject()
        {
            //var logger = new Mock<ILogger>();
            //Debug.AddLogger(logger.Object);
            //var city = "cebu";
            

            //Debug.WriteLine(city, Category1);
            //logger.Verify(l => l.WriteLine(city, Category1));

        }

        [Test]
        public void TestDebugWriteLineString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
       
            string message = "message1"; 
            Trace.WriteLine(message);
            logger.Verify(l => l.WriteLine(message));

        }
        [Test]
        public void TestDebugWriteLineStringLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            string message = "message1";
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            Trace.WriteLine(message,logTypeInfo);
            logger.Verify(l => l.WriteLine(message, logTypeInfo));

        }

        [Test]
        public void TestDebugWriteLineStringString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            string message = "message1";
            string category = "category1";

            Trace.WriteLine(message, category);
            logger.Verify(l => l.WriteLine(message, category));

        }


        #endregion WriteLine

        #region WriteLineIf
        [Test]
        public void TestDebugWriteLineIfBoolException()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            var ex = new Exception();
            bool isValid = true;
            bool isNotValid = false;
            Trace.WriteLineIf(isValid,ex);
            logger.Verify(l => l.WriteLineIf(isValid, ex));

        }

        [Test]
        public void TestDebugWriteLineIfBoolObject()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);
            
            bool isValid = true;
            bool isNotValid = false;
            Trace.WriteLineIf(isValid, logger);
            logger.Verify(l => l.WriteLineIf(isValid, logger));

        }


        [Test]
        public void TestDebugWriteLineIfBoolObjectLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            bool isValid = true;
            bool isNotValid = false;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;

            Trace.WriteLineIf(isValid, logger, logTypeCritical);
            logger.Verify(l => l.WriteLineIf(isValid, logger, logTypeCritical));

        }
        [Test]
        public void TestDebugWriteLineIfBoolObjectString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            bool isValid = true;
            bool isNotValid = false;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            string msge = "hello world";
            Trace.WriteLineIf(isValid, logger, msge);
            logger.Verify(l => l.WriteLineIf(isValid, logger, msge));

        }

        [Test]
        public void TestDebugWriteLineIfBoolString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            bool isValid = true;
            bool isNotValid = false;
           
            string msge = "hello world";
            Trace.WriteLineIf(isValid,msge);
            logger.Verify(l => l.WriteLineIf(isValid, msge));

        }

        [Test]
        public void TestDebugWriteLineIfBoolStringLogTypeEnum()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            bool isValid = true;
            bool isNotValid = false;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            string msge = "hello world";
            Trace.WriteLineIf(isValid, msge, logTypeInfo);
            logger.Verify(l => l.WriteLineIf(isValid, msge, logTypeInfo));

        }

        [Test]
        public void TestDebugWriteLineIfBoolStringString()
        {
            var logger = new Mock<ILogger>();
            Trace.AddLogger(logger.Object);

            bool isValid = true;
            bool isNotValid = false;
            LogTypeEnum logTypeInfo = LogTypeEnum.Info;
            LogTypeEnum logTypeCritical = LogTypeEnum.Critical;
            string msge = "hello world";
            string msge2 = "hello world 2";
            Trace.WriteLineIf(isValid, msge, msge2);
            logger.Verify(l => l.WriteLineIf(isValid, msge, msge2));

        }
        #endregion WriteLineIf


    }
}