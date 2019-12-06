using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SupportEntities
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid UniqueIdentifier { get; set; }
    }
}
