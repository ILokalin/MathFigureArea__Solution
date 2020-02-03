using System;

namespace FigureLibrary
{
    public class NotValidateException : ApplicationException
    {
        public NotValidateException() { }

        public NotValidateException(string message) : base(message) { }

        public NotValidateException(string message, Exception inner) : base(message, inner) { }
    }
}
