using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.ContactMeDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class ContactMeProfile:Profile
    {
        public ContactMeProfile()
        {
            CreateMap<ContactMeAddDto, ContactMe>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ContactMeUpdateDto, ContactMe>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ContactMe, ContactMeUpdateDto>();
        }
    }
}
