using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.HasKey(p => p.PerguntaId);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.HasOne(p => p.Autor).WithMany(p => p.Perguntas);

            builder.HasOne(p => p.Categoria).WithMany(p => p.Perguntas);
        }
    }
}
