using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Articles.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> GetErrorMessages(this ModelStateDictionary modelstate)
        {
            return modelstate.Keys.SelectMany(key =>
                modelstate[key].Errors.Select(err => $"Property: {key}. Message: {(err.Exception == null ? err.ErrorMessage : err.Exception.Message)}"));

        }
    }
}