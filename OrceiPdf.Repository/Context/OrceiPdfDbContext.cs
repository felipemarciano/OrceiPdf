using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Repository.Repository
{
    public class OrceiPdfDbContext : IdentityDbContext<User, Roles, Guid>
    {
        public OrceiPdfDbContext(DbContextOptions<OrceiPdfDbContext> options)
            : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
