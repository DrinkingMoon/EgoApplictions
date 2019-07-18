using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Infrastructure
{    /// <summary>
     /// Represents the error which occurs in the execution of the domain logic.
     /// </summary>
    public class SystemException : Exception
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>SystemException</c> class.
        /// </summary>
        public SystemException() : base() { }
        /// <summary>
        /// Initializes a new instance of <c>SystemException</c> class.
        /// </summary>
        /// <param name="message">The error message to be provided to the exception.</param>
        public SystemException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of <c>SystemException</c> class.
        /// </summary>
        /// <param name="message">The error message to be provided to the exception.</param>
        /// <param name="innerException">The inner exception which causes this exception to occur.</param>
        public SystemException(string message, Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// Initializes a new instance of <c>SystemException</c> class.
        /// </summary>
        /// <param name="format">The string formatter for the error message.</param>
        /// <param name="args">The parameters that are used by the string formatter to format the error message.</param>
        public SystemException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
