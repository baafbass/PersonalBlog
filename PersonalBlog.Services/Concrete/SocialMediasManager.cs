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
    public class SocialMediasManager : ISocialMediasService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediasManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<SocialMediasDto>> Add(SocialMediasAddDto socialMediasAddDto,string createdByName)
        {
           
                var socialMedia = _mapper.Map<SocialMedias>(socialMediasAddDto);
                socialMedia.CreatedByName = createdByName;
                socialMedia.ModifiedByName = createdByName;
                socialMedia.ModifiedTime = DateTime.Now; 
                var addedMedia = await _unitOfWork.SocialMedias.AddAsync(socialMedia);
                await _unitOfWork.SaveAsync();

            return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto
            {
                SocialMedias = addedMedia,
                ResultStatus = ResultStatus.Success,
                Info = "The Social Media Account Is Registered Successfully"
            },"The Social Media Account Is Registered Successfully");
        }

        public async Task<IResult> Delete(int socialMediaAccountId,string modifiedByName)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == socialMediaAccountId);

            if(socialMedia !=null)
            {
                socialMedia.IsDeleted = true;
                socialMedia.ModifiedTime = DateTime.Now;
                socialMedia.ModifiedByName = modifiedByName;
                await _unitOfWork.SocialMedias.UpdateAsync(socialMedia);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Social Media Account Was Successfully deleted");
            }
            return new Result(ResultStatus.Error, "Error, There is no such as element");
        }

        public async Task<IDataResult<SocialMediasDto>> Get(int socialMediaAccountId)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == socialMediaAccountId);
            if(socialMedia!=null)
            {
                return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto 
                {
                    SocialMedias = socialMedia,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SocialMediasDto>(ResultStatus.Error, new SocialMediasDto 
            {
             ResultStatus = ResultStatus.Error,
             SocialMedias = null,
             Info = "Error,No record is found"
            }, "Error, No record is found");
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAll()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync();
            if(socialMedias.Count>-1)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success,
                    new SocialMediasListDto 
                    {
                        SocialMedias = socialMedias,
                        ResultStatus = ResultStatus.Success,
                    });
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, new SocialMediasListDto
            {
                ResultStatus = ResultStatus.Error,
                Info = "No Element is found",
                SocialMedias = null
            }, "No element is found") ;
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAllByNonDelete()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync(x => x.IsDeleted == false);
            if(socialMedias.Count>-1)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success, new SocialMediasListDto
                {
                    SocialMedias = socialMedias,
                    ResultStatus = ResultStatus.Success
                }) ;
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, new SocialMediasListDto
            {
                Info = "Elements was not found",
                SocialMedias = null,
                ResultStatus = ResultStatus.Error
            }, "Elements was not found") ;
        }

        public async Task<IDataResult<SocialMediasListDto>> GetAllByNonDeleteAndActive()
        {
            var socialMedias = await _unitOfWork.SocialMedias.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (socialMedias.Count > -1)
            {
                return new DataResult<SocialMediasListDto>(ResultStatus.Success,
                    new SocialMediasListDto 
                    {
                        SocialMedias = socialMedias,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<SocialMediasListDto>(ResultStatus.Error, new SocialMediasListDto
            { 
             SocialMedias = null,
             Info = "Elements Was not found",
             ResultStatus = ResultStatus.Error
            }, "Elements was not found");
        }

        public async Task<IDataResult<SocialMediasUpdateDto>> GetUpdateDto(int socialMediaAccountId)
        {
            var account = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == socialMediaAccountId);

            if(account!=null)
            {
                var accountUpdateDto = _mapper.Map<SocialMediasUpdateDto>(account);

                return new DataResult<SocialMediasUpdateDto>(ResultStatus.Success, accountUpdateDto);
            }
            return new DataResult<SocialMediasUpdateDto>(ResultStatus.Error, null, "Error,No Element is Found");
        }



        public async Task<IResult> HardDelete(int socialMediaAccountId)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetAsync(x => x.ID == socialMediaAccountId);
           
            if(socialMedia!=null)
            {
                await _unitOfWork.SocialMedias.DeleteAsync(socialMedia);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"Your Account Was Deleted Successfully");
            }
            return new Result(ResultStatus.Error); 
        }

        public async Task<IDataResult<SocialMediasDto>> Update(SocialMediasUpdateDto socialMediasUpdateDto,string modifiedByName)
        {
           
                var socialMedia = _mapper.Map<SocialMedias>(socialMediasUpdateDto);
                socialMedia.ModifiedByName = modifiedByName;
                socialMedia.ModifiedTime = DateTime.Now;
                var UpdatedMedia = await _unitOfWork.SocialMedias.UpdateAsync(socialMedia);
                await _unitOfWork.SaveAsync();
                return new DataResult<SocialMediasDto>(ResultStatus.Success, new SocialMediasDto
                { 
                    SocialMedias = UpdatedMedia,
                    ResultStatus = ResultStatus.Success,
                    Info = "Your Account was successfully Updated"
                });
        }
    }
}
