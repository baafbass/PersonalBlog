using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Experiences: EntityBase,IEntity
    {
        public string experienceTitle { get; set; }
        public string jobPosition { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
