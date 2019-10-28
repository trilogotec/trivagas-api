using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Mapping;

namespace TriVagas.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        private readonly IHostEnvironment _env;

        public DataContext(IHostEnvironment env)
        {
            _env = env;
        }

        public DbSet<Opportunity> Opportunities {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                         .SetBasePath(_env.ContentRootPath)
                         .AddJsonFile("appsettings.json")
                         .Build();

            optionsBuilder.UseMySQL(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OpportunityMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}