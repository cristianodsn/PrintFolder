using System;

namespace rascunho.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException (string message) : base(message) { }
    }
}
