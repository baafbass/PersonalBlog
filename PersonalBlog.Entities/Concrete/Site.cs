using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Site: EntityBase,IEntity
    {
        public string siteName { get; set; }
        public string siteKeywords { get; set; }
        public string Logo { get; set; }
        public string LogoTitle { get; set; }
    }
}
