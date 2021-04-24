using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrceiPdf.Domain.Models;
using System;

namespace OrceiPdf.Repository.Repository
{
    public class OrceiPdfDbContext : IdentityDbContext<User, Roles, Guid>
    {
        public OrceiPdfDbContext(DbContextOptions<OrceiPdfDbContext> options)
            : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<OrcamentoItem> OrcamentoItens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
