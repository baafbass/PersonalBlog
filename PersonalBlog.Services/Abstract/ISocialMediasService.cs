using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ISocialMediasService
    {
        Task<IDataResult<SocialMediasDto>> Get(int socialMediaAccountId);
        Task<IDataResult<SocialMediasUpdateDto>> GetUpdateDto(int socialMediaAccountId);
        Task<IDataResult<SocialMediasListDto>> GetAll();
        Task<IDataResult<SocialMediasListDto>> GetAllByNonDelete();
        Task<IDataResult<SocialMediasListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SocialMediasDto>> Add(SocialMediasAddDto socialMediasAddDto,string createdByName);
        Task<IDataResult<SocialMediasDto>> Update(SocialMediasUpdateDto socialMediasUpdateDto,string modifiedByName);
        Task<IResult> Delete(int socialMediaAccountId,string modifiedByName);
        Task<IResult> HardDelete(int socialMediaAccountId);
    }
}
