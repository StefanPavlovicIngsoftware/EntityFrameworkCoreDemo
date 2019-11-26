using Application.DataTransferObjects;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ReverseMap();

            CreateMap<ProductDto, Product>()
               .ReverseMap();

            CreateMap<OrderDto, Order>()
               .ReverseMap();
        }
    }
}
