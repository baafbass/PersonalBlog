using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Abstract
{
    public interface IArticlesRepository:IEntityRepository<Articles>
    {
        Task<IList<Articles>> GetAllOrderByDescIdAsync(Expression<Func<Articles, bool>> predicate = null, params Expression<Func<Articles, object>>[] includeProperties);
        Task<IList<Articles>> Get3MostReadAsync(Expression<Func<Articles, bool>> predicate = null, params Expression<Func<Articles, object>>[] includeProperties);
    }
}
