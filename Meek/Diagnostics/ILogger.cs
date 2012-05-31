using System;


namespace Meek.Diagnostics
{
    /// <summary>
    /// Interface for ILogger
    /// </summary>
    public interface ILogger
    {
        #region Write
        /// <summary>
        /// Writes the value of the object's ToString() method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        /// An object whose name is sent to the Listeners. 
        /// </param>
        void Write(object value);

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
        void Write(object value, string category);

        /// <summary>
        /// Writes a message to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        void Write(string message);

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
        void Write(string message, string category);

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
        void Write(string message, LogTypeEnum logType);

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
        void Write(object value, LogTypeEnum logType);

        /// <summary>
        /// Writes the exception that occur during application execution to the trace listeners in the Listernes collection
        /// </summary>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write. 
        ///  </param>
        void Write(Exception exception);

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
        void WriteIf(bool condition, object value);

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
        void WriteIf(bool condition, string message);

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
        void WriteIf(bool condition, object value, string category);

        

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
        void WriteIf(bool condition, string message, string category);

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
        /// 
        void WriteIf(bool condition, object value, LogTypeEnum logType);

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
        void WriteIf(bool condition, string message, LogTypeEnum logType);

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
        void WriteIf(bool condition, Exception exception);
        #endregion WriteIf

        #region WriteLine
        /// <summary>
        /// Writes the value of the object's ToString method to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="value">
        /// Type: System.Object
        ///An object whose name is sent to the Listeners. 
        /// </param>
        void WriteLine(object value);

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
        void WriteLine(object value, string category);

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
        void WriteLine(string format, params object[] args);

        /// <summary>
        /// Writes a message followed by a line terminator to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="message">
        /// Type: System.String
        /// A message to write. 
        /// </param>
        void WriteLine(string message);

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
        void WriteLine(string message, string category);

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
        void WriteLine(object value, LogTypeEnum logType);

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
        void WriteLine(string message, LogTypeEnum logType);

        /// <summary>
        /// Writes a exeception followed by a line terminator to the trace listeners in the Listeners collection and defines the type of log..
        /// </summary>
        /// <param name="exception">
        ///  Type: System.Exception
        ///  An exception to write.
        /// </param>
        void WriteLine(Exception exception);
        #endregion WriteLine

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
        void WriteLineIf(bool condition, object value);

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
        void WriteLineIf(bool condition, object value, string category);

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
        void WriteLineIf(bool condition, string message);

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
        void WriteLineIf(bool condition, string message, string category);

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
        void WriteLineIf(bool condition, object value, LogTypeEnum logType);

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
        void WriteLineIf(bool condition, string message, LogTypeEnum logType);

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
        void WriteLineIf(bool condition, Exception exception);
        #endregion WriteLineIf

    }
}

