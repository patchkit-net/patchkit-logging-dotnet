using System;
using System.Reflection;

namespace PatchKit.Logging
{
    /// <summary>
    /// Source of logged message.
    /// </summary>
    public struct MessageSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSource"/> struct.
        /// </summary>
        public MessageSource(Type type, MethodBase method, string fileName, int? fileLineNumber)
        {
            Type = type;
            Method = method;
            FileName = fileName;
            FileLineNumber = fileLineNumber;
        }

        /// <summary>
        /// Type from which message was logged.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Method from which message was logged.
        /// </summary>
        public MethodBase Method { get; }

        /// <summary>
        /// Source file name from which message was logged.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Source file line number from which message was logged.
        /// </summary>
        public int? FileLineNumber { get; }
    }
}