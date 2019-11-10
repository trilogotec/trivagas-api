using Desafio.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Context
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCompany>().HasKey(a => new { a.CompanyId, a.UserId });

            modelBuilder.Entity<User>().HasIndex(a => a.Email).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Access> Accesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
