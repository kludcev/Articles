using Articles.Core.Entities;

namespace Articles.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Articles.Core.ArticlesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Articles.Core.ArticlesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Articles.AddOrUpdate(p => p.Title, 
                new Article() {Id = Guid.NewGuid(), Title = "First Article", Description = "Lorem Ipsum", CreatedDate = DateTimeOffset.UtcNow},
                new Article() { Id = Guid.NewGuid(), Title = "Second Article", Description = "Lorem Ipsum", CreatedDate = DateTimeOffset.UtcNow });
        }
    }
}
