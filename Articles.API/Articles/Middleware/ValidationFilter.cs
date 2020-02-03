using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Articles.Extensions;
using Autofac.Integration.WebApi;

namespace Articles.Middleware
{
    internal class ValidationFilter : IAutofacActionFilter
    {
        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!actionContext.ModelState.IsValid)
            {
                throw new ValidationException(String.Join(Environment.NewLine, actionContext.ModelState.GetErrorMessages()));
            }
            return Task.FromResult<object>(null);
        }
    }
}