using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(a => a.CategoriaId);

            builder.Property(a => a.Titulo)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("varchar(max)");

            
        }
    }
}
