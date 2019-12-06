using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Interfaces;
using Application.QueryObject;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void CreateOrder(OrderDto order)
        {
            var orderDomainModel = _mapper.Map<Order>(order);
            _unitOfWork.Orders.Add(orderDomainModel);
            _unitOfWork.SaveChanges();
        }

        public OrderDto GetOrder(int orderId)
        {
            var order = _unitOfWork.Orders
                .AsNoTracking()
                .WithRelatedData()
                .SingleOrDefault(o => o.OrderId == orderId);

            if (order == null)
                throw new NonExistingEntityException();

            return _mapper.Map<OrderDto>(order);
        }
    }
}
