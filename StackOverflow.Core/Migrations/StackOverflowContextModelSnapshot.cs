﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflow.Core.Contexts;

namespace StackOverflow.Core.Migrations
{
    [DbContext(typeof(StackOverflowContext))]
    partial class StackOverflowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StackOverflow.Core.Entities.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("AutorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("PerguntaId");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("PerguntaId");

                    b.HasKey("RespostaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Resposta", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Pergunta", "ObjPergunta")
                        .WithMany()
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
