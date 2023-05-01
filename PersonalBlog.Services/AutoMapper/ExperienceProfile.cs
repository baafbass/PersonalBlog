using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class ExperienceProfile:Profile
    {
        public ExperienceProfile()
        {
            CreateMap<ExperiencesAddDto, Experiences>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ExperiencesUpdateDto, Experiences>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Experiences, ExperiencesUpdateDto>();
        }
    }
}
