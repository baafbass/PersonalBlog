using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class SocialMediasProfile:Profile
    {
        public SocialMediasProfile()
        {
            CreateMap<SocialMediasAddDto, SocialMedias>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SocialMediasUpdateDto, SocialMedias>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SocialMedias, SocialMediasUpdateDto>();
        }
    }
}
