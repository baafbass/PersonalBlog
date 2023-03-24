using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SocialMediasDtos
{
    public class SocialMediasListDto
    {
        public IList<SocialMedias> SocialMedias { get; set; }
    }
}
