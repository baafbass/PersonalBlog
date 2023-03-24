using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SiteDtos
{
    public class SiteListDto
    {
        public IList<Site> Site { get; set; }
    }
}
