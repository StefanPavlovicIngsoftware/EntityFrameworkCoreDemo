using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void CreateCustomer(CustomerDto customer)
        {
            var domainCustomer = _mapper.Map<Customer>(customer);
            
            _unitOfWork.Customers.Add(domainCustomer);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new NonExistingEntityExceptions();

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.SaveChanges();
        }

        public CustomerDto GetCustomer(int customerId)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new NonExistingEntityExceptions();

            return _mapper.Map<CustomerDto>(customer);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            var domainCustomer = _mapper.Map<Customer>(customer);

            _unitOfWork.Customers.Add(domainCustomer);
            _unitOfWork.Entry(customer).State = EntityState.Modified;

            _unitOfWork.SaveChanges();
        }
    }
}
