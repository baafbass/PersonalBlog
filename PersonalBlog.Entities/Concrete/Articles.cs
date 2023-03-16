using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Concrete
{
    public class Articles:EntityBase,IEntity
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public int Views { get; set; } = 0;
        public string SeoTags { get; set; }
        public string SeoDescription { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        ICollection<Comments> Comments { get; set; }

    }
}
