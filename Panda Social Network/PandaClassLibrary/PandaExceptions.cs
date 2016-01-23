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

    public class PandaAlreadyThereException : ApplicationException
    {
        public PandaAlreadyThereException() : this("Panda already exists in the network!") { }

        public PandaAlreadyThereException(string message) : base(message) { }

        public PandaAlreadyThereException(string message, Exception innerException) : base(message, innerException) { }

        protected PandaAlreadyThereException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class PandasAlreadyFriendsException : ApplicationException
    {
        public PandasAlreadyFriendsException() : this("These panda are already friends.") { }

        public PandasAlreadyFriendsException(string message) : base(message) { }

        public PandasAlreadyFriendsException(string message, Exception innerException) : base(message, innerException) { }

        protected PandasAlreadyFriendsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
