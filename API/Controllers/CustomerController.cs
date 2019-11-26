using Application.DataTransferObjects;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("{controller}/{action}/{id?}")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpPost]
        public IActionResult Create(CustomerDto customer) 
        {
            _customerService.CreateCustomer(customer);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return new JsonResult(customer);
        }
    }
}
