using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.HobbiesDtos
{
    public class HobbiesListDtos
    {
        public IList<Hobbies> Hobbies { get; set; }
    }
}
