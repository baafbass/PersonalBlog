using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ArticlesDtos
{
    public class ArticleDto : DtoGetBase
    {
        public Articles Articles { get; set; }
    }
}
