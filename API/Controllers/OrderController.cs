using Application.DataTransferObjects;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("{controller}/{action}/{id?}")]
    public class OrderController : ControllerBase 
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public IActionResult Create(OrderDto order) 
        {
            _orderService.CreateOrder(order);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var order = _orderService.GetOrder(id);
            return new JsonResult(order);
        }
    }
}
