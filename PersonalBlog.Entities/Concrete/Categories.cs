using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Categories:EntityBase,IEntity
    {
        public string Name { get; set; }
        public string CategoryImg { get; set; }
        public string Description { get; set; }
        ICollection<Articles> Articles { get; set; }
    }
}
