using System;
using System.Collections.Generic;

namespace Meek.Diagnostics
{
    public sealed class Trace
    {
        #region Fields
        private static List<ILogger> _loggers;
        #endregion Fields

        /// <summary>
        /// List of ILogger
        /// </summary>
        private static List<ILogger> Loggers
        {
            get
            {
                _loggers = _loggers ?? new List<ILogger>();
                return _loggers;
            }
        }

        /// <summary>
        /// Add a logger on the list 
        /// </summary>
        /// <param name="logger">log</param>
        public static void AddLogger(ILogger logger)
        {
            Loggers.Add(logger);
        }

        #region Write
        /// <summary>
        /// Writes the value of the object's ToString() method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        public static void Write(object value)
        {
            Loggers.ForEach(l => l.Write(value));
        }

        /// <summary>
        /// Writes a category name and the value of the object's ToString() method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners.
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void Write(object value, string category)
        {
            Loggers.ForEach(l => l.Write(value, category));
        }

        /// <summary>
        ///  Writes the value of the object's ToString() method to the trace listeners in the Listeners collection and defines the type of log.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void Write(object value, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.Write(value, logType));
        }

        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        public static void Write(string message)
        {
            Loggers.ForEach(l => l.Write(message));
        }

        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection and defines the type of log.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        ///A message to write.
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void Write(string message, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.Write(message, logType));
        }

        /// <summary>
        /// Writes a category name and a message to the trace listners in the Listeners collection
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        ///A message to write.
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void Write(string message, string category)
        {
            Loggers.ForEach(l => l.Write(message, category));
        }

        /// <summary>
        /// Writes the exception that occur during application execution to the trace listeners in the Listernes collection
        /// </summary>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write. 
        ///  </param>
        public static void Write(Exception exception)
        {
            Loggers.ForEach(l => l.Write(exception));
        }
        #endregion Write

        #region WriteIf
        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        ///Type: System.Boolean
        ///The conditional expression to evaluate. If the condition is true, the value is written to the trace listeners in the collection.
        /// </param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        public static void WriteIf(bool condition, object value)
        {
            Loggers.ForEach(l => l.WriteIf(condition, value));
        }


        /// <summary>
        /// Writes a category name and the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.</param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. </param>
        public static void WriteIf(bool condition, object value, string category)
        {
            Loggers.ForEach(l => l.WriteIf(condition, value, category));
        }


        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the message is written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        public static void WriteIf(bool condition, string message)
        {
            Loggers.ForEach(l => l.WriteIf(condition, message));
        }


        /// <summary>
        /// Writes a category name and message to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and message are written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void WriteIf(bool condition, string message, string category)
        {
            Loggers.ForEach(l => l.WriteIf(condition, message, category));
        }


        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true and defines the type of log..
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteIf(bool condition, object value, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteIf(condition, value, logType));
        }


        /// <summary>
        ///  Writes a message to the trace listeners in the Listeners collection if a condition is true and defines the type of log.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write.
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteIf(bool condition, string message, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteIf(condition, message, logType));
        }

        /// <summary>
        ///  Writes an exception to the trace listeners in the Listeners collection if a condition is true and defines the type of log.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write.
        /// </param>
        public static void WriteIf(bool condition, Exception exception)
        {
            Loggers.ForEach(l => l.WriteIf(condition, exception));
        }
        #endregion WriteIf
        
        #region WriteLine

        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        ///An object whose name is sent to the Listeners. 
        /// </param>
        public static void WriteLine(object value)
        {
            Loggers.ForEach(l => l.WriteLine(value));
        }



        /// <summary>
        /// Writes a category name and the value of the object's ToString method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void WriteLine(object value, string category)
        {
            Loggers.ForEach(l => l.WriteLine(value, category));

        }

        /// <summary>
        /// Writes a message followed by a line terminator to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        public static void WriteLine(string message)
        {
            Loggers.ForEach(l => l.WriteLine(message));
            
        }

        /// <summary>
        /// Writes a category name and message to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void WriteLine(string message, string category)
        {

            Loggers.ForEach(l => l.WriteLine(message, category));
        }

        /// <summary>
        /// Writes a formatted message followed by a line terminator to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="format">
        /// Type: System.String
        /// A composite format string (see Remarks) that contains text intermixed with zero or more format items, which correspond to objects in the args array.
        /// </param>
        /// <param name="args">
        /// Type: System.Object[]
        /// An object array containing zero or more objects to format. 
        /// </param>
        public static void WriteLine(string format, params object[] args)
        {
            Loggers.ForEach(l => l.WriteLine(format, args));
        }


        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection and defines the type of log..
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteLine(object value, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteLine(value, logType));
        }

        /// <summary>
        /// Writes a message followed by a line terminator to the trace listeners in the Listeners collection and defines the type of log.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteLine(string message, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteLine(message, logType));
        }


        /// <summary>
        /// Writes a exeception followed by a line terminator to the trace listeners in the Listeners collection and defines the type of log..
        /// </summary>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write.
        /// </param>
        public static void WriteLine(Exception exception)
        {
            Loggers.ForEach(l => l.WriteLine(exception));
        }
        #endregion

        #region WriteLineIf
        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the value is written to the trace listeners in the collection.
        /// </param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        public static void WriteLineIf(bool condition, object value)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition,value));
        }

        /// <summary>
        /// Writes a category name and the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void WriteLineIf(bool condition, object value, string category)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition, value,category));

        }

        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        public static void WriteLineIf(bool condition, string message)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition,message));

        }

        /// <summary>
        /// Writes a category name and message to the trace listeners in the Listeners collection if a condition is true.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        /// <param name="category">
        /// Type: System.String
        /// A category name used to organize the output. 
        /// </param>
        public static void WriteLineIf(bool condition, string message, string category)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition, message, category));
        }

        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection if a condition is true and defines the type of log.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteLineIf(bool condition, object value, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition, value, logType));

        }

        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection if a condition is true and defines the type of log.
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        /// <param name="logType">
        /// Type: Meek.Diagnostics.LogTypeEnum
        /// A log type enum used to organize the output. 
        /// </param>
        public static void WriteLineIf(bool condition, string message, LogTypeEnum logType)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition, message, logType));
        }

        /// <summary>
        /// Writes the exception that occur during application execution to the trace listeners in the Listernes collection
        /// </summary>
        /// <param name="condition">
        /// Type: System.Boolean
        /// The conditional expression to evaluate. If the condition is true, the category name and value are written to the trace listeners in the collection.
        /// </param>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write.
        /// </param>
        public static void WriteLineIf(bool condition,Exception exception)
        {
            Loggers.ForEach(l => l.WriteLineIf(condition, exception));
        }
      
        #endregion

    }
}
