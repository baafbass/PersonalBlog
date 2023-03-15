using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class SocialMedias: EntityBase,IEntity
    {
        public string  MediaName { get; set; }
        public string MediaLogo { get; set; }
        public string MediaURL { get; set; }
    }
}
