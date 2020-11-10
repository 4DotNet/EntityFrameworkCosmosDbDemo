using Dotnet.CosmosDB.Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dotnet.CosmosDB.Demo.Data
{
    public class CosmosDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public CosmosDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {     
            var accountEndpoint = _config["Cosmos:Endpoint"];  
            var accountKey =  _config["Cosmos:Key"];  
            var dbName =  _config["Cosmos:Database"];  
            optionsBuilder.UseCosmos(accountEndpoint, accountKey, dbName);  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultContainer("4DotNet");

            modelBuilder.Entity<Developer>().OwnsOne(o => o.CurrentEmployer);
            modelBuilder.Entity<Developer>().OwnsMany(o => o.PreviousEmployers);
        }


        public DbSet<Developer> Developers { get; set; }


    }
}
