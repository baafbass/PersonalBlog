using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ISiteService
    {
        Task<IDataResult<SiteDto>> Get(int id);
        Task<IDataResult<SiteDto>> update(SiteUpdateDto siteUpdateDto);
    }
}
