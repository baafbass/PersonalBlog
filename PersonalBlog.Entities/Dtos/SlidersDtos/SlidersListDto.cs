using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SlidersDtos
{
    public class SlidersListDto
    {
        public IList<HomePageSliders> Sliders { get; set; }
    }
}
