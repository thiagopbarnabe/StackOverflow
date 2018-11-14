using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class RespostaConfiguration : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.HasKey(r => r.RespostaId);

            builder.Property(r => r.Descricao)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.HasOne(p => p.Pergunta)
                .WithMany(p=>p.Respostas)
                .HasForeignKey(r => r.PerguntaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Respostas)
                .HasForeignKey(p => p.AutorId);

            builder.HasOne(p => p.Categoria).WithMany(p => p.Respostas);

        }
    }
}
