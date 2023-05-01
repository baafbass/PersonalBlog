using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class ContactInfoProfile:Profile
    {
        public ContactInfoProfile()
        {
            CreateMap<ContactInfoUpdateDto, ContactInfo>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ContactInfo, ContactInfoUpdateDto>();
        }
    }
}
