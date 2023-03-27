using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Entities.Dtos.SummaryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.AutoMapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Summary, SummaryUpdateDto>().ReverseMap();
            CreateMap<Hobbies, HobbiesAddDtos>().ReverseMap();
            CreateMap<Hobbies, HobbiesUpdateDtos>().ReverseMap();
            CreateMap<SocialMedias, SocialMediasAddDto>().ReverseMap();
            CreateMap<SocialMedias, SocialMediasUpdateDto>().ReverseMap();
        }
    }
}
