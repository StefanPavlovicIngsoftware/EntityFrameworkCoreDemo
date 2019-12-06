using System;

namespace Application.DataTransferObjects
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
