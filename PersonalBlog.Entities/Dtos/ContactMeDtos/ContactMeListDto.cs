using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ContactMeDtos
{
    public class ContactMeListDto
    {
        public IList<ContactMe> ContactMe { get; set; }
    }
}
