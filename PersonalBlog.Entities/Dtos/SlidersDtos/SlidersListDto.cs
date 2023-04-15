using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SlidersDtos
{
    public class SlidersListDto : DtoGetBase
    {
        public IList<HomePageSliders> Sliders { get; set; }
    }
}
