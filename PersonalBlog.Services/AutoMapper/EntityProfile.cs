using AutoMapper;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.AboutMeDtos;
using PersonalBlog.Entities.Dtos.AdminDtos;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Entities.Dtos.ContactMeDtos;
using PersonalBlog.Entities.Dtos.EducationDtos;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Entities.Dtos.SlidersDtos;
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
            CreateMap<HomePageSliders, SlidersAddDto>().ReverseMap();
            CreateMap<HomePageSliders, SlidersUpdateDto>().ReverseMap();
            CreateMap<Skills, SkillsAddDto>().ReverseMap();
            CreateMap<Skills, SkillsUpdateDto>().ReverseMap();
            CreateMap<Experiences, ExperiencesAddDto>().ReverseMap();
            CreateMap<Experiences, ExperiencesUpdateDto>().ReverseMap();
            CreateMap<ContactMe,ContactMeAddDto>().ReverseMap();
            CreateMap<ContactMeUpdateDto, ContactMe>().ReverseMap();
            CreateMap<SiteUpdateDto, Site>().ReverseMap();
            CreateMap<AboutMeUpdateDto, AboutMe>().ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ReverseMap();
            CreateMap<EducationAddDto, Education>().ReverseMap();
            CreateMap<EducationUpdateDto, Education>().ReverseMap();
            CreateMap<ContactInfoUpdateDto, ContactInfo>().ReverseMap();
        }
    }
}
