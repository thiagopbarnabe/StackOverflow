using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(a => a.TagId);

            builder.Property(a => a.Nome)
               .IsRequired()
               .HasColumnType("varchar(10)");
            
            
        }
    }
}
