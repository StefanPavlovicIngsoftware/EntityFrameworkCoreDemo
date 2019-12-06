using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Mock
{
    public static class CustomerMockExtensions
    {
        public static void SeedMockCustomers(this IApplicationUnitOfWork applicationUnitOfWork)
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, UniqueIdentifier = Guid.NewGuid(), FirstName = "John", LastName = "Doe"},
                new Customer(){ Id = 2, UniqueIdentifier = Guid.NewGuid(), FirstName = "Johnny", LastName = "Public"},
                new Customer(){ Id = 3, UniqueIdentifier = Guid.NewGuid(), FirstName = "Stiven", LastName = "King"},
                new Customer(){ Id = 4, UniqueIdentifier = Guid.NewGuid(), FirstName = "Michael", LastName = "Jordan"},
                new Customer(){ Id = 5, UniqueIdentifier = Guid.NewGuid(), FirstName = "Anne", LastName = "Li"},
                new Customer(){ Id = 6, UniqueIdentifier = Guid.NewGuid(), FirstName = "Brian", LastName = "McAlly"},
                new Customer(){ Id = 7, UniqueIdentifier = Guid.NewGuid(), FirstName = "Bobby", LastName = "Chan"},
            };

            applicationUnitOfWork.Customers.AddRange(customers);
            applicationUnitOfWork.SaveChanges();
        }
    }
}
