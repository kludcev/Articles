using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Articles.Core.Entities.Configuration
{
    internal class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        internal ArticleConfiguration()
        {
            this.ToTable(nameof(Article));
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Title)
                .IsMaxLength()
                .IsRequired();
            this.Property(x => x.Description)
                .IsMaxLength()
                .IsRequired();
            this.Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
