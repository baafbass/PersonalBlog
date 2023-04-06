using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.AboutMeDtos
{
    public class AboutMeDto : DtoGetBase
    {
        public AboutMe AboutMe { get; set; }
    }
}
