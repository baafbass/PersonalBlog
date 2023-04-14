using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.ContactMeDtos
{
    public class ContactMeDto : DtoGetBase
    {
        public ContactMe ContactMe { get; set; }
    }
}
