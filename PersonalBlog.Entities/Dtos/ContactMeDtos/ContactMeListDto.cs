using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ContactMeDtos
{
    public class ContactMeListDto : DtoGetBase
    {
        public IList<ContactMe> ContactMe { get; set; }
    }
}
