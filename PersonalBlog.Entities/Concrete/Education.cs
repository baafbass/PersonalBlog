using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Education : EntityBase,IEntity
    {
        public string educationTitle { get; set; }
        public string School { get; set; }
        public string Duration { get; set; }
        public string GradePointAverage { get; set; }
        public string Description { get; set; }
    }
}
