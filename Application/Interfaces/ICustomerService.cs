using Application.DataTransferObjects;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto customer);
        CustomerDto GetCustomer(int customerId);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
    }
}
