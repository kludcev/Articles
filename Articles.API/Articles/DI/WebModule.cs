using System.Reflection;
using Articles.Controllers;
using Articles.Middleware;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace Articles.DI
{
    internal class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ValidationFilter>().AsWebApiActionFilterFor<BaseApiController>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ExceptionFilter>().AsWebApiExceptionFilterFor<BaseApiController>().InstancePerLifetimeScope();
        }
    }
}