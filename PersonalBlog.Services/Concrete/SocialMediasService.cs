using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using PersonalBlog.Shared.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Concrete
{
    public class SocialMediasService : ISocialMediasService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediasService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<SocialMediasDto>> Add(SocialMediasAddDto socialMediasAddDto)
        {
            if(socialMediasAddDto!=null)
            {
                var socialMedia = _mapper.Map<SocialMedias>(socialMediasAddDto);
                await _unitOfWork.SocialMedias.AddAsync(socialMedia);
                socialMedia.CreatedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto { SocialMedias = socialMedia });
            }
            return new DataResult<SocialMediasDto>(ResultStatus.Error, null, "Error, failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == id);
            if(socialMedia !=null)
            {
                socialMedia.IsDeleted = true;
                await _unitOfWork.SocialMedias.UpdateAsync(socialMedia);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, There is no such as element");
        }

        public async Task<IDataResult<SocialMediasDto>> Get(int id)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == id);
            if(socialMedia!=null)
            {
                return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto { SocialMedias = socialMedia });
            }
            return new DataResult<SocialMediasDto>(ResultStatus.Error, null, "Error, No record is found");
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAll()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync();
            if(socialMedias.Count>0)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success, new SocialMediasListDto { SocialMedias = socialMedias });
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, null, "No element is found");
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAllByNonDelete()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync(x => x.IsDeleted == false);
            if(socialMedias.Count>0)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success, new SocialMediasListDto { SocialMedias = socialMedias });
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, null, "Elements was not found");
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAllByNonDeleteAndActive()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (socialMedias.Count > 0)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success, new SocialMediasListDto { SocialMedias = socialMedias });
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, null, "Elements was not found");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == id);
           
            if(socialMedia!=null)
            {
                await _unitOfWork.SocialMedias.DeleteAsync(socialMedia);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error); 
        }

        public async Task<IDataResult<SocialMediasDto>> Update(SocialMediasUpdateDto socialMediasUpdateDto)
        {
            if(socialMediasUpdateDto!=null)
            {
                var socialMedia = _mapper.Map<SocialMedias>(socialMediasUpdateDto);
                await _unitOfWork.SocialMedias.UpdateAsync(socialMedia);
                socialMedia.ModifiedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto { SocialMedias = socialMedia });
            }
                return new DataResult<SocialMediasDto>(ResultStatus.Error, null, "Invalid, check the information you put");
        }
    }
}
