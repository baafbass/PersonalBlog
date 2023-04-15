using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SummaryDtos
{
    public class SummaryDto : DtoGetBase
    {
        public Summary Summary { get; set; }
    }
}
