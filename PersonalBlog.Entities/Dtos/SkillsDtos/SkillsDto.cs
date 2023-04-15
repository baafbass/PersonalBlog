using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Entities.Dtos.SkillsDtos
{
    public class SkillsDto : DtoGetBase
    {
        public Skills Skills { get; set; }
    }
}
