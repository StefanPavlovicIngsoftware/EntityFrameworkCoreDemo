using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customerEntity)
        {
            customerEntity.HasMany(c => c.Contacts)
                .WithOne(c => c.Customer);

            customerEntity.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            customerEntity.Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(30);            
        }
    }
}
