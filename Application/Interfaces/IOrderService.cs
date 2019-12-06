using Application.DataTransferObjects;

namespace Application.Interfaces
{
    public interface IOrderService 
    {
        void CreateOrder(OrderDto order);
        OrderDto GetOrder(int orderId);
    }
}
