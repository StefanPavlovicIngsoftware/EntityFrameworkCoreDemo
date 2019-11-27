using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServiceTests()
        {            
        }

        [TestMethod]
        public void CreateCustomerTest() 
        {
        
        }
    }
}
