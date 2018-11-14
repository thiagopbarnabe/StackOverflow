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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PerguntaTag>  PerguntasTag { get; set; }
        public DbSet<RespostaTag> RespostasTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            if (!contextOptionsBuilder.IsConfigured)
            {
                contextOptionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StackOverflow;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pergunta>(new PerguntaConfiguration().Configure);
            modelBuilder.Entity<Resposta>(new RespostaConfiguration().Configure);
            modelBuilder.Entity<Autor>(new AutorConfiguration().Configure);
            modelBuilder.Entity<Categoria>(new CategoriaConfiguration().Configure);
            modelBuilder.Entity<Tag>(new TagConfiguration().Configure);

        }
    }
}
