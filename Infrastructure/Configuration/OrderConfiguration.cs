using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderEntity)
        {
            orderEntity.HasOne(o => o.Customer)
                .WithMany(c => c.Orders);

            orderEntity.HasOne(o => o.Customer)
               .WithMany(p => p.Orders);
        }
    }
}
