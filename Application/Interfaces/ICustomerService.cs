using Application.DataTransferObjects;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDto> GetCustomers(CustomerPaggingFilterDto dto);
        void CreateCustomer(CustomerDto customer);
        CustomerDto GetCustomer(int customerId);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
    }
}
