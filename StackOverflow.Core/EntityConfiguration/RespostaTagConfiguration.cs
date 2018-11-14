using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.EntityConfiguration
{
    public class RespostaTagConfiguration : IEntityTypeConfiguration<RespostaTag>
    {
        public void Configure(EntityTypeBuilder<RespostaTag> builder)
        {
            builder.HasKey(a => a.RespostaTagId);

            builder.HasOne(p => p.Resposta).WithMany(p => p.RespostaTags).HasForeignKey(p=>p.RespostaId);
            builder.HasOne(p => p.Tag).WithMany(p => p.RespostaTags).HasForeignKey(p=>p.TagId);
            
            
        }
    }
}
