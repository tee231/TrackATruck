using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Data.Entities;

namespace TrackATruckMgt.Infrstructure.Configurations
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {

            CreateMap<DriverDto, Driver>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<Truck, TruckDto>().ReverseMap();

        }

    }
}

