using System.Data.Entity;
using System.Reflection;
using Articles.Core.Entities;

namespace Articles.Core
{
    public sealed class ArticlesContext : DbContext
    {
        private const string DEFAULT_NAME_OR_CONNECTION_STRING = "name=ArticlesContext";
        public ArticlesContext(string connectionString) : base(connectionString)
        {

        }
        public ArticlesContext() : this(DEFAULT_NAME_OR_CONNECTION_STRING)
        {

        }
        public DbSet<Article> Articles { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(ArticlesContext));
            modelBuilder.Configurations.AddFromAssembly(coreAssembly);
        }
    }
}
