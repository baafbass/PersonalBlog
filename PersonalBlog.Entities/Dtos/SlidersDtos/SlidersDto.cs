using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos
{
    public class SlidersDto :DtoGetBase
    {
        public HomePageSliders Sliders { get; set; }
    }
}
