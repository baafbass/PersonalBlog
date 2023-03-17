using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Hobbies:EntityBase,IEntity
    {
        public string hobbies { get; set; }
    }
}
