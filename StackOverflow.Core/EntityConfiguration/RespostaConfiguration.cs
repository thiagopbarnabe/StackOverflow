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
                .HasColumnType("varchar(1000)");

            builder.HasOne(p => p.ObjPergunta)
                .WithMany()
                .HasForeignKey(r => r.PerguntaId);
        }
    }
}
