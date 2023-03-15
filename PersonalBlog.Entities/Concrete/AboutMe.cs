using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class AboutMe:EntityBase,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string profilPicture { get; set; }
        public string Job { get; set; }
        public string JobIcon { get; set; }
        public DateTime Birthday { get; set; }
        public string CV { get; set; }
    }
}
