﻿using AutoMapper;
using BLL.Models;
using DAL.DataHelper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDTO>()
                .ForMember(dest=> dest.PhotoUrl,
                opt=>opt.MapFrom(src=>src.Photos.
                FirstOrDefault(x=>x.IsMain).Url)).ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDTO>();
            CreateMap<MemberUpdateDTO, AppUser>();
        }
    }
}
