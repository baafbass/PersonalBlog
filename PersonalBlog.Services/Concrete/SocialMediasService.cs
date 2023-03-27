using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Concrete
{
    public class SocialMediasService : ISocialMediasService
    {
        public Task<IDataResult<SocialMediasDto>> Add(SocialMediasAddDto socialMediasAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SocialMediasDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SocialMediasListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SocialMediasListDto>> GetAllByNonDelete()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SocialMediasListDto>> GetAllByNonDeleteAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SocialMediasDto>> Update(SocialMediasUpdateDto socialMediasUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
