using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.EducationDtos;

namespace PersonalBlog.Services.AutoMapper
{
    public class EducationProfile: Profile
    {
        public EducationProfile()
        {
            CreateMap<EducationAddDto, Education>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<EducationUpdateDto, Education>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Education, EducationUpdateDto>();
        }
    }
}
