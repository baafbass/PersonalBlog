using PersonalBlog.Entities.Dtos.AboutMeDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IAboutMeService
    {
        Task<IDataResult<AboutMeDto>> Get(int aboutMeId);
        Task<IDataResult<AboutMeDto>> Update(AboutMeUpdateDto aboutMeUpdateDto,string modifiedByName);
        Task<IDataResult<AboutMeUpdateDto>> GetUpdateDto(int aboutMeId);
        Task<IResult> Delete(int categoryId,string modifiedByName);
        Task<IResult> HardDelete(int categoryId);
    }
}
