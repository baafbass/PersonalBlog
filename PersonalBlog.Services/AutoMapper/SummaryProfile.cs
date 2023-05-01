using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SummaryDtos;

namespace PersonalBlog.Services.AutoMapper
{
    public class SummaryProfile:Profile
    {
        public SummaryProfile()
        {
            CreateMap<SummaryUpdateDto, Summary>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Summary, SummaryUpdateDto>();
        }
    }
}
