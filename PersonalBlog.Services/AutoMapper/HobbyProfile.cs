using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class HobbyProfile:Profile
    {
        public HobbyProfile()
        {
            CreateMap<HobbiesAddDtos, Hobbies>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<HobbiesUpdateDtos, Hobbies>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Hobbies, HobbiesUpdateDtos>();
        }
    }
}
