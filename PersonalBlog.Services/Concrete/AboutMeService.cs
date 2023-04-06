using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.AboutMeDtos;
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
    public class AboutMeService : IAboutMeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutMeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var result = await _unitOfWork.AboutMe.AnyAsync(x => x.ID == categoryId);
            if(result)
            {
                var aboutMe = await _unitOfWork.AboutMe.GetAsync(x => x.ID == categoryId);
                aboutMe.IsDeleted = true;
                aboutMe.ModifiedByName = modifiedByName;
                aboutMe.ModifiedTime = DateTime.Now;
                await _unitOfWork.AboutMe.UpdateAsync(aboutMe);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"About ME Informations was updated successfully");
            }
            return new Result(ResultStatus.Error, "Error,Record was not found");
        }


        public async Task<IDataResult<AboutMeDto>> Get(int aboutMeId)
        {
            var aboutMe = await _unitOfWork.AboutMe.GetAsync(x => x.ID == aboutMeId);
            if(aboutMe!=null)
            {
                return new DataResult<AboutMeDto>(ResultStatus.Success, new AboutMeDto
                { 
                    AboutMe = aboutMe,
                    ResultStatus = ResultStatus.Success,
                    Info = "Operation Successed"
                });
            }
            return new DataResult<AboutMeDto>(ResultStatus.Error, new AboutMeDto
            {
                AboutMe = null,
                Info = "Error,NO record is found",
                ResultStatus = ResultStatus.Error
            }) ;
        }

       public async Task<IResult> HardDelete(int categoryId)
        {
            return new Result(ResultStatus.Success, "Unfortenatly can't be deleted");
        }

        public async Task<IDataResult<AboutMeDto>> Update(AboutMeUpdateDto aboutMeUpdateDto,string modifiedByName)
        {
                var aboutMe = _mapper.Map<AboutMe>(aboutMeUpdateDto);
                aboutMe.ModifiedByName = modifiedByName;
                aboutMe.ModifiedTime = DateTime.Now;
                var updatedaboutMe = await _unitOfWork.AboutMe.UpdateAsync(aboutMe);
                await _unitOfWork.SaveAsync();
                return new DataResult<AboutMeDto>(ResultStatus.Success, new AboutMeDto
                {
                    AboutMe = updatedaboutMe,
                    Info = "About Me Informations was successfully Updated",
                    ResultStatus = ResultStatus.Success
                });
        }

        public async Task<IDataResult<AboutMeUpdateDto>> GetUpdateDto(int aboutMeId)
        {
            var aboutMe = await _unitOfWork.AboutMe.GetAsync(x => x.ID == aboutMeId);
            if(aboutMe!=null)
            {
                var aboutMeUpdatedDto = _mapper.Map<AboutMeUpdateDto>(aboutMe);
                return new DataResult<AboutMeUpdateDto>(ResultStatus.Success, aboutMeUpdatedDto);
            }
            return new DataResult<AboutMeUpdateDto>(ResultStatus.Error, null, "Failed to Get The Updated About Me");
        }
    }
}
