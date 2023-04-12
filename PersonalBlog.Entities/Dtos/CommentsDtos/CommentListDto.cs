using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.CommentsDtos
{
    public class CommentListDto : DtoGetBase
    {
        public IList<Comments> Comments { get; set; }
    }
}
