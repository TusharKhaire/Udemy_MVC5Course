using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.Dtos;

namespace Udemy_MVC5Course.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }

    }

}