using Microsoft.EntityFrameworkCore;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfHomePageSlidersRepository:EfEntityRepositoryBase<HomePageSliders>
    {
        public EfHomePageSlidersRepository(DbContext context):base(context)
        {

        }
    }
}
