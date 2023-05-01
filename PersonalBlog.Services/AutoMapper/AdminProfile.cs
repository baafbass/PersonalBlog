using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.AdminDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
   public class AdminProfile :Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminUpdateDto, Admin>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Admin, AdminUpdateDto>();
        }
    }
}
