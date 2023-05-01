using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
    public class SiteProfile:Profile
    {
        public SiteProfile()
        {
            CreateMap<SiteUpdateDto, Site>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Site, SiteUpdateDto>();
        }
    }
}
