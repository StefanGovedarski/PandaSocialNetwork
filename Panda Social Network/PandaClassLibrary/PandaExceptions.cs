using System;
using System.Runtime.Serialization;

namespace PandaClassLibrary
{
    public class InvalidPandaEmailException : ApplicationException
    {
        public InvalidPandaEmailException() : this("Invalid email input!") { }

        public InvalidPandaEmailException(string message) : base(message) { }

        public InvalidPandaEmailException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidPandaEmailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
