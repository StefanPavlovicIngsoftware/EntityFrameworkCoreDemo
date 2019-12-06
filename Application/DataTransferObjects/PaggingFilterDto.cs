using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class PaggingFilterDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public PaggingFilterDto(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }

    public class CustomerPaggingFilterDto : PaggingFilterDto
    {
        public CustomerOrderBy OrderBy { get; set; }
        public OrderType OrderType { get; set; }

        public CustomerPaggingFilterDto(
            CustomerOrderBy orderBy, 
            OrderType orderType, 
            int skip,
            int take)
            : base(skip, take)
        {
            OrderBy = orderBy;
            OrderType = orderType;
        }
    }

    public enum CustomerOrderBy
    {
        SimpleOrder = 1,
        FirstName = 2,
        LastName = 3
    }

    public enum OrderType 
    {
        Asc = 1,
        Desc = 2
    }
}
