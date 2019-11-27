using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class SeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Customer>().HasData(new Customer(){Id = 1, FirstName = "John", LastName = "Doe"});
            modelBuilder.Entity<Customer>().HasData(new Customer(){Id = 2, FirstName = "John", LastName = "Public"});
            modelBuilder.Entity<Customer>().HasData(new Customer(){Id = 3, FirstName = "Richard", LastName = "Doe"});
            modelBuilder.Entity<Customer>().HasData(new Customer(){Id = 4, FirstName = "Jane", LastName = "Doe"});
            modelBuilder.Entity<Customer>().HasData(new Customer(){Id = 5, FirstName = "Johnny", LastName = "Doe"});
        }
    }
}
