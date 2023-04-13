using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.EducationDtos
{
    public class EducationDto : DtoGetBase
    {
        public Education Education { get; set; }
    }
}
