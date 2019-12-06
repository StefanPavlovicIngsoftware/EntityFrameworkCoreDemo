using Application.DataTransferObjects;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.QueryObject
{
    public static class CustomerQueryObject
    {
        public static IQueryable<Customer> OrderCustomersBy(
            this IQueryable<Customer> queriableCustomers, 
            CustomerOrderBy orderBy, 
            OrderType orderType) 
        {
            switch (orderBy)
            {
                case CustomerOrderBy.SimpleOrder:
                    if (orderType == OrderType.Asc)
                        return queriableCustomers.OrderBy(c => c.Id);
                    else 
                        return queriableCustomers.OrderByDescending(c => c.Id);
                case CustomerOrderBy.FirstName:
                    if (orderType == OrderType.Asc)
                        return queriableCustomers.OrderBy(c => c.FirstName);
                    else
                        return queriableCustomers.OrderByDescending(c => c.FirstName);
                case CustomerOrderBy.LastName:
                    if (orderType == OrderType.Asc)
                        return queriableCustomers.OrderBy(c => c.LastName);
                    else
                        return queriableCustomers.OrderByDescending(c => c.LastName);
                default:
                    throw new ArgumentOutOfRangeException($"Argument {nameof(CustomerOrderBy)} out of range, don't expect {orderBy.ToString()}");
            }            
        }
    }
}

