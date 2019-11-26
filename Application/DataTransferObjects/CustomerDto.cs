using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
