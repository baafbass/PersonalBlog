using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Shared.Utilities;
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
        Task<IDataResult<SiteDto>> Get(int SiteId);
        Task<IDataResult<SiteUpdateDto>> GetUpdateDto(int SiteId);
        Task<IDataResult<SiteDto>> Update(SiteUpdateDto siteUpdateDto,string modifiedByName);
        Task<IResult> Delete(int SiteId, string modifiedByName);
        Task<IResult> HardDelete(int SiteID);
    }
}
