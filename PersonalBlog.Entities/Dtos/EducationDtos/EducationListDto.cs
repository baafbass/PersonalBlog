using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.EducationDtos
{
    public class EducationListDto : DtoGetBase
    {
        public IList<Education> Education { get; set; }
    }
}
