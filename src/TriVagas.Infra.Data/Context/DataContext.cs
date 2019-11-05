using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TriVagas.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        private readonly IHostEnvironment _env;

        public DataContext(IHostEnvironment env)
        {
            _env = env;
        }

        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json")
                .Build();

            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(new CityMap().Configure);
            modelBuilder.Entity<Class>(new ClassMap().Configure);
            modelBuilder.Entity<Company>(new CompanyMap().Configure);
            modelBuilder.Entity<CompanyUser>(new CompanyUserMap().Configure);
            modelBuilder.Entity<Job>(new JobMap().Configure);
            modelBuilder.Entity<Like>(new LikeMap().Configure);
            modelBuilder.Entity<Opportunity>(new OpportunityMap().Configure);
            modelBuilder.Entity<Page>(new PageMap().Configure);
            modelBuilder.Entity<PageUser>(new PageUserMap().Configure);
            modelBuilder.Entity<Position>(new PositionMap().Configure);
            modelBuilder.Entity<Profile>(new ProfileMap().Configure);
            modelBuilder.Entity<Skill>(new SkillMap().Configure);
            modelBuilder.Entity<State>(new StateMap().Configure);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}