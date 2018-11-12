using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => a.AutorId);

            builder.Property(a => a.Nome)
               .IsRequired()
               .HasColumnType("varchar(30)");

            builder.Property(a => a.Login)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(a => a.Senha)
               .IsRequired()
               .HasColumnType("varchar(30)");
        }
    }
}
