using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SlidersDtos;

namespace PersonalBlog.Services.AutoMapper
{
    public class SliderProfile:Profile
    {
        public SliderProfile()
        {
            CreateMap<SlidersAddDto, HomePageSliders>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SlidersUpdateDto, HomePageSliders>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<HomePageSliders, SlidersUpdateDto>();
        }
    }
}
