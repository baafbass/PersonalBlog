using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.CategoryDtos
{
    public class CategoryListDto
    {
      public IList<Categories> Categories { get; set; }
    }
}
