using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
   public class ContactInfo:EntityBase,IEntity
    {
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string  City { get; set; }
        public string Adress { get; set; }
    }
}
