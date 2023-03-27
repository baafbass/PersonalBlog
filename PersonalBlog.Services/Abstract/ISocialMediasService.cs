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
        Task<IDataResult<SocialMediasDto>> Get(int id);
        Task<IDataResult<SocialMediasListDto>> GetAll();
        Task<IDataResult<SocialMediasListDto>> GetAllByNonDelete();
        Task<IDataResult<SocialMediasListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SocialMediasDto>> Add(SocialMediasAddDto socialMediasAddDto);
        Task<IDataResult<SocialMediasDto>> Update(SocialMediasUpdateDto socialMediasUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
