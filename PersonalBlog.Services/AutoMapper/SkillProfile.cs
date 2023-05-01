using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SkillsDtos;

namespace PersonalBlog.Services.AutoMapper
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<SkillsAddDto, Skills>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SkillsUpdateDto, Skills>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Skills, SkillsUpdateDto>();
        }
    }
}
