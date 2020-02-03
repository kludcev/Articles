using Articles.Core.Services;
using Articles.Core.Services.Interfaces;
using Autofac;

namespace Articles.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticlesContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ArticlesService>().As<IArticlesService>().InstancePerLifetimeScope();
        }
    }
}
