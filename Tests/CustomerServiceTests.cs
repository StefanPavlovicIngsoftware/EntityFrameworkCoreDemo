using Application;
using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Mock;

namespace Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private IApplicationUnitOfWork _applicationUnitOfWork;
        private ICustomerService _customerService;

        #region TestLifecycleMethods

        [TestInitialize]
        public void Initialize() 
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _applicationUnitOfWork = new ApplicationContext(options);

            _applicationUnitOfWork.SeedMockCustomers();

            _applicationUnitOfWork.Database.EnsureCreated();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            _customerService = new CustomerService(_applicationUnitOfWork, mapper);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _applicationUnitOfWork.Database.EnsureDeleted();
            _applicationUnitOfWork.Dispose();
        }

        #endregion

        [TestMethod]
        public void GetAllCustomers() 
        {
            //Arrange
            var customersFilter = new CustomerPaggingFilterDto(
                CustomerOrderBy.SimpleOrder, OrderType.Asc, 0, 10);

            //Act
            var customers = _customerService.GetCustomers(customersFilter);

            //Assert
            Assert.IsNotNull(customers);
            Assert.AreEqual(7, customers.Count);
        }

        [TestMethod]
        public void GetCustomersByFirstNameAsc() 
        {
            //Arrange
            var customersFilter = new CustomerPaggingFilterDto(
                CustomerOrderBy.FirstName, OrderType.Asc, 0, 10);

            //Act
            var customers = _customerService.GetCustomers(customersFilter);

            var customersAscFromDatabase = _applicationUnitOfWork.Customers
                .OrderBy(c => c.FirstName)
                .Skip(0)
                .Take(10)
                .Select(c => c.FirstName)
                .ToList();

            //Assert
            Assert.AreEqual(7, customers.Count);
            Assert.IsTrue(customers.Select(c => c.FirstName).SequenceEqual(customersAscFromDatabase));
        }

        [TestMethod]
        public void GetCustomersByFirstNameDesc()
        {
            //Arrange
            var customersFilter = new CustomerPaggingFilterDto(
                CustomerOrderBy.FirstName, OrderType.Desc, 0, 10);

            //Act
            var customers = _customerService.GetCustomers(customersFilter);

            var customersDescFromDatabase = _applicationUnitOfWork.Customers
                .OrderByDescending(c => c.FirstName)
                .Skip(0)
                .Take(10)
                .Select(c => c.FirstName)
                .ToList();

            //Assert
            Assert.AreEqual(7, customers.Count);
            Assert.IsTrue(customers.Select(c => c.FirstName).SequenceEqual(customersDescFromDatabase));
        }

        [TestMethod]
        public void GetCustomersByLastNameAsc()
        {
            //Arrange
            var customersFilter = new CustomerPaggingFilterDto(
                CustomerOrderBy.LastName, OrderType.Asc, 0, 10);

            //Act
            var customers = _customerService.GetCustomers(customersFilter);

            var customersAscFromDatabase = _applicationUnitOfWork.Customers
                .OrderBy(c => c.LastName)
                .Skip(0)
                .Take(10)
                .Select(c => c.LastName)
                .ToList();

            //Assert
            Assert.AreEqual(7, customers.Count);
            Assert.IsTrue(customers.Select(c => c.LastName).SequenceEqual(customersAscFromDatabase));
        }

        [TestMethod]
        public void GetCustomersByLastNameDesc()
        {
            //Arrange
            var customersFilter = new CustomerPaggingFilterDto(
                CustomerOrderBy.LastName, OrderType.Desc, 0, 10);

            //Act
            var customers = _customerService.GetCustomers(customersFilter);

            var customersDescFromDatabase = _applicationUnitOfWork.Customers
                .OrderByDescending(c => c.LastName)
                .Skip(0)
                .Take(10)
                .Select(c => c.LastName)
                .ToList();

            //Assert
            Assert.AreEqual(7, customers.Count);
            Assert.IsTrue(customers.Select(c => c.LastName).SequenceEqual(customersDescFromDatabase));
        }
    }
}
