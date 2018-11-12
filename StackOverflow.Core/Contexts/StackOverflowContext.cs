using Microsoft.EntityFrameworkCore;
using StackOverflow.Core.EntityConfiguration;
using StackOverflow.Core.Entities;

namespace StackOverflow.Core.Contexts
{
    public class StackOverflowContext : DbContext
    {
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            if (!contextOptionsBuilder.IsConfigured)
            {
                contextOptionsBuilder.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=StackOverflow;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pergunta>(new PerguntaConfiguration().Configure);
            modelBuilder.Entity<Resposta>(new RespostaConfiguration().Configure);
            modelBuilder.Entity<Autor>(new AutorConfiguration().Configure);
        }
    }
}
