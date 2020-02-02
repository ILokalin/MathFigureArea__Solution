using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public class NotValidateException : ApplicationException
    {
        public NotValidateException() {}

        public NotValidateException(string message) : base(message) {}

        public NotValidateException(string message, Exception inner) : base(message, inner) {}
    }
}
