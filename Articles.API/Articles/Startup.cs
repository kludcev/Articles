using System.Reflection;
using System.Web.Http;
using Articles.Controllers;
using Articles.Core;
using Articles.Core.Services;
using Articles.Core.Services.Interfaces;
using Articles.DI;
using Articles.Middleware;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Owin.Cors;
using Microsoft.Web.Infrastructure.DynamicValidationHelper;
using Owin;

namespace Articles
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // STANDARD WEB API SETUP:

            // Get your HttpConfiguration. In OWIN, you'll create one
            // rather than using GlobalConfiguration.
            var config = new HttpConfiguration();

            // Register your Web API controllers.
            var builder = new ContainerBuilder();
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new CoreModule());
            var mapper = AutomapperFactory.GetMapper(Assembly.GetAssembly(typeof(IArticlesService)));
            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // OWIN WEB API SETUP:

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);


        }
    }
}

