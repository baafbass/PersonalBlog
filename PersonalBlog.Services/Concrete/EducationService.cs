using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.EducationDtos;
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
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<EducationDto>> Add(EducationAddDto educationAddDto,string createdByName)
        {
            
                var education = _mapper.Map<Education>(educationAddDto);
                education.ModifiedByName = createdByName;
                education.ModifiedTime = DateTime.Now;
                var addedEducation = await _unitOfWork.Education.AddAsync(education);
                await _unitOfWork.SaveAsync();
            return new DataResult<EducationDto>(ResultStatus.Success,
                new EducationDto
                {
                    Education = addedEducation,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Education with the {education.educationTitle} was successfully Added "
                }) ;
        }

        public async Task<IResult> Delete(int educationId,string modifiedByName)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == educationId);
            if(education!=null)
            {
                education.IsDeleted = true;
                education.ModifiedTime = DateTime.Now;
                education.ModifiedByName = modifiedByName;
                await _unitOfWork.Education.UpdateAsync(education);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Eduation with the {education.educationTitle} title was successfully deleted !");
            }
            return new Result(ResultStatus.Error, $"Error, Failed to be Deleted");
        }

        public async Task<IDataResult<EducationDto>> Get(int educationId)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == educationId);
            if(education!=null)
            {
                return new DataResult<EducationDto>(ResultStatus.Success, 
                    new EducationDto
                    {
                        Education = education,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<EducationDto>(ResultStatus.Error,
                new EducationDto
                { 
                 Education=null,
                 Info = "Error,Failed to Get the Elements",
                 ResultStatus = ResultStatus.Error
                }, "Error,No Record is found");
        }

        public async Task<IDataResult<EducationListDto>> GetAll()
        {
            var educations = await _unitOfWork.Education.GetAllAsync();
            if(educations.Count > -1)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success, 
                    new EducationListDto 
                    {
                        Education = educations,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error, 
                new EducationListDto
                {
                    Education = null,
                    Info = "Error,Failed to get all the elements",
                    ResultStatus =ResultStatus.Error
                }, "Error,Failed to get all Elements");
        }

        public async Task<IDataResult<EducationListDto>> GetAllByNonDelete()
        {
            var educations = await _unitOfWork.Education.GetAllAsync(x=>x.IsDeleted==false);
            if (educations.Count > -1)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success,
                    new EducationListDto 
                    {
                        Education = educations,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error,
                new EducationListDto
                {
                    Education=null,
                    ResultStatus = ResultStatus.Error,
                    Info = "Error,Failed to get all elements"
                }, "Error,Failed to get all Elements");
        }

        public async Task<IDataResult<EducationListDto>> GetAllByNonDeleteAndActive()
        {
            var educations = await _unitOfWork.Education.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (educations.Count > -1)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success,
                    new EducationListDto 
                    {
                        Education = educations,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error, new EducationListDto
            { 
             Education = null,
             Info = "Error,Failed to get all Elements",
             ResultStatus = ResultStatus.Error
            }, "Error,Failed to get all Elements");
        }

        public async Task<IDataResult<EducationUpdateDto>> GetUpdateDto(int educationId)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == educationId);
            if(education!=null)
            {
                var updateEducationDto = _mapper.Map<EducationUpdateDto>(education);
                return new DataResult<EducationUpdateDto>(ResultStatus.Success, updateEducationDto);
            }
            return new DataResult<EducationUpdateDto>(ResultStatus.Error, null, "Error,The element was not found");
        }

        public async Task<IResult> HardDelete(int educationId)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == educationId);
            if(education!=null)
            {
                await _unitOfWork.Education.DeleteAsync(education);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Education with the {education.educationTitle} title was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "Error,Failed to Delete");
        }

        public async Task<IDataResult<EducationDto>> Update(EducationUpdateDto educationUpdateDto,string modifiedByName)
        {
          
                var education = _mapper.Map<Education>(educationUpdateDto);
                education.ModifiedByName = modifiedByName;
                education.ModifiedTime = DateTime.Now;
                var updatedEducation = await _unitOfWork.Education.UpdateAsync(education);
                await _unitOfWork.SaveAsync();
                return new DataResult<EducationDto>(ResultStatus.Success,
                    new EducationDto
                    {
                        Education = updatedEducation,
                        ResultStatus = ResultStatus.Success,
                        Info = $"Education of {updatedEducation.educationTitle} title was successfully updated ! "
                    });
        }
    }
}
