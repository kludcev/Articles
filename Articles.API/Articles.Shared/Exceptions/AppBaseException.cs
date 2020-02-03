using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Articles.Shared.Exceptions
{
    public abstract class AppBaseException : Exception
    {
        public abstract HttpStatusCode HttpCode { get; }

        protected AppBaseException(string errorMessage) : base(errorMessage) { }
    }
}
