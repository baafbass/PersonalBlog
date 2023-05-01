using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.AboutMeDtos;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.AutoMapper
{
   public class AboutMeProfile : Profile
    {
        public AboutMeProfile()
        {
            CreateMap<AboutMeUpdateDto, AboutMe>().ForMember(x => x.ModifiedTime, o => o.MapFrom(x => DateTime.Now));
            CreateMap<AboutMe, AboutMeUpdateDto>();
        }
    }
}
