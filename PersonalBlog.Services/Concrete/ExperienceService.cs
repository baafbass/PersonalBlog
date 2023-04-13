using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
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
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExperienceService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ExperiencesDto>> Add(ExperiencesAddDto experiencesAddDto,string createdByName)
        {
           
                var experience = _mapper.Map<Experiences>(experiencesAddDto);
                experience.ModifiedByName = createdByName;
                experience.CreatedByName = createdByName;
                experience.ModifiedTime = DateTime.Now;
               var addedExperience = await _unitOfWork.Experiences.AddAsync(experience);
                await _unitOfWork.SaveAsync();
            return new DataResult<ExperiencesDto>(ResultStatus.Success, new ExperiencesDto
            {
                Experiences = addedExperience,
                ResultStatus = ResultStatus.Success,
                Info = $"The experience with the {experience.experienceTitle} Title was successfully added!"
            }, $"The experience with the {experience.experienceTitle} Title was successfully added!") ;
        }

        public async Task<IResult> Delete(int experienceId,string modifiedByName)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == experienceId);
            if(experience!=null)
            {
                experience.IsDeleted = true;
                experience.ModifiedTime = DateTime.Now;
                experience.CreatedByName = modifiedByName;
                await _unitOfWork.Experiences.UpdateAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Experience with {experience.experienceTitle} was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "Error, Deletion is Failed");
        }

        public async Task<IDataResult<ExperiencesDto>> Get(int experienceId)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == experienceId);
            if(experience!=null)
            {
                return new DataResult<ExperiencesDto>(ResultStatus.Success,
                    new ExperiencesDto 
                    { 
                        Experiences = experience,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<ExperiencesDto>(ResultStatus.Error, new ExperiencesDto 
            {
             Experiences=null,
             ResultStatus =ResultStatus.Error,
             Info = "Error, No record is Found"
            }, "Error,No record is found");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAll()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync();
            if(experience.Count>-1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success,
                    new ExperiencesListDto 
                    {
                        Experiences = experience,
                        ResultStatus = ResultStatus.Success
                     });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, new ExperiencesListDto 
            {
              Experiences=null,
              ResultStatus =ResultStatus.Error,
              Info = "Operation Failed"
            }, "Operation failed");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDelete()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync(x=>x.IsDeleted==false);
            if (experience.Count > -1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, 
                    new ExperiencesListDto 
                    {
                        Experiences = experience,
                        ResultStatus =ResultStatus.Success
                    });
            }
                return new DataResult<ExperiencesListDto>(ResultStatus.Error,
                new ExperiencesListDto 
                {
                 Experiences =null,
                 ResultStatus = ResultStatus.Success,
                 Info = "Operation failed !"
                }, "Operation failed");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDeleteAndActive()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync(x=>x.IsDeleted==false && x.IsActive==true);
            if (experience.Count > -1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success,
                    new ExperiencesListDto
                    {
                        Experiences = experience,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error,
            new ExperiencesListDto
            {
                Experiences = null,
                ResultStatus = ResultStatus.Success,
                Info = "Operation failed !"
            }, "Operation failed");
        }

        public async Task<IResult> HardDelete(int experienceId)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == experienceId);
            if (experience != null)
            {
                await _unitOfWork.Experiences.DeleteAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Experience with the {experience.experienceTitle} Title was successfully Deleted ! ");
            }
            return new Result(ResultStatus.Error, "Error, Deletion is failed");
        }

        public async Task<IDataResult<ExperiencesUpdateDto>> GetUpdateDto(int experienceId)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == experienceId);
            if(experience!=null)
            {
                var experienceUpdateDto = _mapper.Map<ExperiencesUpdateDto>(experience);
                return new DataResult<ExperiencesUpdateDto>(ResultStatus.Success, experienceUpdateDto);
            }
            return new DataResult<ExperiencesUpdateDto>(ResultStatus.Error, null, "Error,It was not found");
        }

        public async Task<IDataResult<ExperiencesDto>> Update(ExperiencesUpdateDto experiencesUpdateDto,string modifiedByName)
        {
           
            var experience = _mapper.Map<Experiences>(experiencesUpdateDto);
            experience.ModifiedTime = DateTime.Now;
            experience.ModifiedByName = modifiedByName;
            var updatedExperience = await _unitOfWork.Experiences.UpdateAsync(experience);
            await _unitOfWork.SaveAsync();
            return new DataResult<ExperiencesDto>(ResultStatus.Success, 
                new ExperiencesDto
                {
                    Experiences = updatedExperience,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Experience with the {experience.experienceTitle} was successfully updated"
                });
        }
    }
}
