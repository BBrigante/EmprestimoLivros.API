﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmprestimosLivros.API.Models
{
    public partial class ControleEmprestimoLivroContext : DbContext
    {
        public ControleEmprestimoLivroContext()
        {
        }

        public ControleEmprestimoLivroContext(DbContextOptions<ControleEmprestimoLivroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.LceIdClienteNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Cliente");

                entity.HasOne(d => d.LceIdLivroNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Livro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultCOnnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}