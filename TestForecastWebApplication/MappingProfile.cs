using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForecast.WebApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request.ForecastRequest, DTO.ForecastRequest>()
                .AfterMap((src, dest) => dest.OrderDirection = src.OrderDirection.ToString().ToLower());
        }
    }
}
