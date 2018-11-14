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

            modelBuilder.Entity("StackOverflow.Core.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("PerguntaId");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.PerguntaTag", b =>
                {
                    b.Property<int>("PerguntaTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PerguntaId");

                    b.Property<int>("TagId");

                    b.HasKey("PerguntaTagId");

                    b.HasIndex("PerguntaId");

                    b.HasIndex("TagId");

                    b.ToTable("PerguntasTag");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("PerguntaId");

                    b.HasKey("RespostaId");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.RespostaTag", b =>
                {
                    b.Property<int>("RespostaTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RespostaId");

                    b.Property<int>("TagId");

                    b.HasKey("RespostaTagId");

                    b.HasIndex("RespostaId");

                    b.HasIndex("TagId");

                    b.ToTable("RespostasTag");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("PerguntaId");

                    b.HasKey("TagId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Pergunta", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Autor", "Autor")
                        .WithMany("Perguntas")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StackOverflow.Core.Entities.Categoria", "Categoria")
                        .WithMany("Perguntas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.PerguntaTag", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Pergunta", "Pergunta")
                        .WithMany("PerguntaTags")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StackOverflow.Core.Entities.Tag", "Tag")
                        .WithMany("PerguntaTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Resposta", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Autor", "Autor")
                        .WithMany("Respostas")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StackOverflow.Core.Entities.Categoria", "Categoria")
                        .WithMany("Respostas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StackOverflow.Core.Entities.Pergunta", "Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.RespostaTag", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Resposta", "Resposta")
                        .WithMany("RespostaTags")
                        .HasForeignKey("RespostaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StackOverflow.Core.Entities.Tag", "Tag")
                        .WithMany("RespostaTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StackOverflow.Core.Entities.Tag", b =>
                {
                    b.HasOne("StackOverflow.Core.Entities.Pergunta")
                        .WithMany("Tags")
                        .HasForeignKey("PerguntaId");
                });
#pragma warning restore 612, 618
        }
    }
}
