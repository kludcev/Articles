using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Articles.Shared.Dto;
using Articles.Shared.Exceptions;
using Autofac.Integration.WebApi;

namespace Articles.Middleware
{
    public class ExceptionFilter : IAutofacExceptionFilter
    {
        public Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            actionExecutedContext.Response = ProcessException(actionExecutedContext.Exception);
            return Task.FromResult<object>(null);
        }

        private HttpResponseMessage ProcessException(Exception ex)
        {
            if (ex is AppBaseException appException)
            {
                return CreateMessage(appException.HttpCode, appException.Message, appException.StackTrace);
            }

            if (ex is ValidationException valEx)
            {
                return CreateMessage(HttpStatusCode.BadRequest, valEx.Message, stackTrace: "");
            }
            return CreateMessage(HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);
        }

        private HttpResponseMessage CreateMessage(HttpStatusCode code, string message, string stackTrace)
        {
            return new HttpResponseMessage(code)
            {
                Content = new ObjectContent(
                    typeof(ErrorResponseDto),
                    new ErrorResponseDto()
                    {
                        Message = message,
                        StackTrace = stackTrace
                    },
                    new JsonMediaTypeFormatter(),
                    mediaType: "application/json")
            };
        }
    }
}