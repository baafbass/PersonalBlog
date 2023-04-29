using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Skills:EntityBase,IEntity
    {
        public string SkillName { get; set; }
        public int Percentage { get; set; }
        public string Note { get; set; }
    }
}
