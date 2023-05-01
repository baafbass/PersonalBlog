using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Entities.Dtos.ArticlesDtos;
using PersonalBlog.Entities.Concrete;

namespace PersonalBlog.Services.AutoMapper
{
   public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticlesAddDto, Articles>().ForMember(des => des.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticlesUpdateDto, Articles>().ForMember(des => des.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Articles, ArticlesUpdateDto>();
        }
    }
}
