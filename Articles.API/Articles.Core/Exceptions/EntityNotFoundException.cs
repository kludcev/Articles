using System.Net;
using Articles.Shared.Exceptions;

namespace Articles.Core.Exceptions
{
    public class EntityNotFoundException : AppBaseException
    {
        public EntityNotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public override HttpStatusCode HttpCode => HttpStatusCode.NotFound;
    }
}
