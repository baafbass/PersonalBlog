using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Abstract
{
    public interface IHobbiesRepository:IEntityRepository<Hobbies>
    {
    }
}
