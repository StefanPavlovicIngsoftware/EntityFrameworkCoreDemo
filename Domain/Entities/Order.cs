using System;

namespace Domain.Entities
{
    public class Order 
    {
        public int OrderId { get; set; }       
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
