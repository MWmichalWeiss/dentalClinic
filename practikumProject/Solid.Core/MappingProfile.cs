﻿using AutoMapper;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<RoleEmployeeDto, RoleEmployee>().ReverseMap();
        }
    }
}