using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.QueryObject
{
    public static class OrderQueryObject
    {
        public static IQueryable<Order> WithRelatedData(this IQueryable<Order> queriableOrders)
        {
            return queriableOrders.Include(o => o.Customer)
                                     .ThenInclude(c => c.Contacts)
                                  .Include(o => o.Product);
        }
    }
}

