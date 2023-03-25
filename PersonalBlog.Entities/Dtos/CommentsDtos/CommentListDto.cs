using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.CommentsDtos
{
    public class CommentListDto
    {
        public IList<Comments> Comments { get; set; }
    }
}
