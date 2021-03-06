﻿using AutoMapper;
using Data.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Configuration
{
  public  class MapProfile :Profile
    {
        public MapProfile()

            
        {

            

            CreateMap<Employee, EmployeeDTO>()
                            .ForMember(x => x.Positions, y => y.MapFrom(x => x.Positions.Select(x => x.Position)))
                            .MaxDepth(5)
                            .ReverseMap();
                            

            CreateMap<Position, PositionDTO>()
                .ForMember(x => x.Employees, c => c.MapFrom(x => x.Employees.Select(x => x.Employee))).MaxDepth(1)
                .ReverseMap();


            CreateMap<EmployeePosition, History>()
                .MaxDepth(1).ReverseMap();
                

        }
    }
}
