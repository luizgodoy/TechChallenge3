using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Models;

namespace TechChallenge.Data.Context
{
    public class techchallengeDbContext : DbContext
    {
        public techchallengeDbContext()
        {
            
        }
        public techchallengeDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<State> States { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(techchallengeDbContext).Assembly);

            modelBuilder.Entity<State>().HasData(StateList.List);
        }
        
        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            await Database.MigrateAsync(cancellationToken);
        }
    }
}
