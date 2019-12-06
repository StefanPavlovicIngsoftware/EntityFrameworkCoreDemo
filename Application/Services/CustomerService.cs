using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Interfaces;
using Application.QueryObject;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(
            IApplicationUnitOfWork unitOfWork,
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
            var customer = _unitOfWork.Customers
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new NonExistingEntityException();

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.SaveChanges();
        }

        public CustomerDto GetCustomer(int customerId)
        {
            var customer = _unitOfWork.Customers
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new NonExistingEntityException();

            return _mapper.Map<CustomerDto>(customer);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            var domainCustomer = _mapper.Map<Customer>(customer);

            _unitOfWork.Customers.Update(domainCustomer);

            _unitOfWork.SaveChanges();
        }

        public List<CustomerDto> GetCustomers(CustomerPaggingFilterDto dto)
        {
            return _unitOfWork.Customers
                .OrderCustomersBy(dto.OrderBy, dto.OrderType)
                .Skip(dto.Skip)
                .Take(dto.Take)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
