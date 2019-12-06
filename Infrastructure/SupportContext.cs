using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SupportContext : DbContext 
    {
        public DbSet<Domain.SupportEntities.Customer> Customers { get; set; }
        public DbSet<Domain.SupportEntities.Product> Products { get; set; }
        public DbSet<Domain.SupportEntities.Ticket> Tickets { get; set; }

        public SupportContext(DbContextOptions<SupportContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Support");

            modelBuilder.Seed();
        }
    }
}
