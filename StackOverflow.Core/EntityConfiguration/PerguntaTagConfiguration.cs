using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class PerguntaTagConfiguration : IEntityTypeConfiguration<PerguntaTag>
    {
        public void Configure(EntityTypeBuilder<PerguntaTag> builder)
        {
            builder.HasKey(a => a.PerguntaTagId);
            builder.HasOne(p => p.Pergunta).WithMany(p => p.PerguntaTags).HasForeignKey(p => p.PerguntaId);
            builder.HasOne(p => p.Tag).WithMany(p => p.PerguntaTags).HasForeignKey(p => p.TagId);
            
        }
    }
}
