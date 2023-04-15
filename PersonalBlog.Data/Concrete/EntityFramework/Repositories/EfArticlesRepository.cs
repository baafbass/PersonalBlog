using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete.EntityFramework.Contexts;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfArticlesRepository: EfEntityRepositoryBase<Articles>,IArticlesRepository
    {
        public EfArticlesRepository(DbContext context):base(context)
        {

        }

        public async Task<IList<Articles>> Get3MostReadAsync(Expression<Func<Articles, bool>> predicate = null, params Expression<Func<Articles, object>>[] includeProperties)
        {
            IQueryable<Articles> query = _context.Set<Articles>();
            if(predicate !=null)
            {
                query = query.Where(predicate);
            }
            if(includeProperties.Any())
            {
                foreach(var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.OrderByDescending(x => x.ID).ToListAsync();
        }

        public async Task<IList<Articles>> GetAllOrderByDescIdAsync(Expression<Func<Articles, bool>> predicate = null, params Expression<Func<Articles, object>>[] includeProperties)
        {
            IQueryable<Articles> query = _context.Set<Articles>();
            if(predicate!=null)
            {
                query = query.Where(predicate);
            }
            if(includeProperties.Any())
            {
                foreach(var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.OrderByDescending(x => x.Views).Take(3).ToListAsync();
        }

        private BlogContext myblogContext
        {
            get
            {

                return _context as BlogContext;
            }
        }
    }
}
