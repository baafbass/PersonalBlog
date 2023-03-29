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
        public async Task<IDataResult<ExperiencesDto>> Add(ExperiencesAddDto experiencesAddDto)
        {
            if(experiencesAddDto!=null)
            {
                var experience = _mapper.Map<Experiences>(experiencesAddDto);
                await _unitOfWork.Experiences.AddAsync(experience);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExperiencesDto>(ResultStatus.Success, new ExperiencesDto { Experiences = experience });
            }
            return new DataResult<ExperiencesDto>(ResultStatus.Error, null, "Error, Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == id);
            if(experience!=null)
            {
                experience.IsDeleted = true;
                await _unitOfWork.Experiences.UpdateAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, Deletion is Failed");
        }

        public async Task<IDataResult<ExperiencesDto>> Get(int id)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == id);
            if(experience!=null)
            {
                return new DataResult<ExperiencesDto>(ResultStatus.Success, new ExperiencesDto { Experiences = experience });
            }
            return new DataResult<ExperiencesDto>(ResultStatus.Error, null, "Error,No record is found");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAll()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync();
            if(experience.Count>0)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto { Experiences = experience });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, null, "Operation failed");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDelete()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync(x=>x.IsDeleted==false);
            if (experience.Count > 0)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto { Experiences = experience });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, null, "Operation failed");
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDeleteAndActive()
        {
            var experience = await _unitOfWork.Experiences.GetAllAsync(x=>x.IsDeleted==false && x.IsActive==true);
            if (experience.Count > 0)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto { Experiences = experience });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, null, "Operation failed");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var experience = await _unitOfWork.Experiences.GetAsync(x => x.ID == id);
            if (experience != null)
            {
                await _unitOfWork.Experiences.DeleteAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, Deletion is failed");
        }

        public async Task<IDataResult<ExperiencesDto>> Update(ExperiencesUpdateDto experiencesUpdateDto)
        {
            if(experiencesUpdateDto!=null)
            { 
            var experience = _mapper.Map<Experiences>(experiencesUpdateDto);
            experience.ModifiedTime = DateTime.Now;
            await _unitOfWork.Experiences.UpdateAsync(experience);
            await _unitOfWork.SaveAsync();
            return new DataResult<ExperiencesDto>(ResultStatus.Success, new ExperiencesDto { Experiences = experience });
             }
            return new DataResult<ExperiencesDto>(ResultStatus.Error, null, "Error, Failed to Update");
        }
    }
}
