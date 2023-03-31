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
        public async Task<IDataResult<EducationDto>> Add(EducationAddDto educationAddDto)
        {
            if(educationAddDto!=null)
            {
                var education = _mapper.Map<Education>(educationAddDto);
                await _unitOfWork.Education.AddAsync(education);
                education.CreatedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<EducationDto>(ResultStatus.Success, new EducationDto { Education = education });
            }
            return new DataResult<EducationDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == id);
            if(education!=null)
            {
                education.IsDeleted = true;
                education.ModifiedTime = DateTime.Now;
                await _unitOfWork.Education.UpdateAsync(education);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, Failed to Delete");
        }

        public async Task<IDataResult<EducationDto>> Get(int id)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == id);
            if(education!=null)
            {
                return new DataResult<EducationDto>(ResultStatus.Success, new EducationDto { Education = education });
            }
            return new DataResult<EducationDto>(ResultStatus.Error, null, "Error,No Record is found");
        }

        public async Task<IDataResult<EducationListDto>> GetAll()
        {
            var educations = await _unitOfWork.Education.GetAllAsync();
            if(educations.Count > 0)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success, new EducationListDto { Education = educations });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error, null, "Error,Failed to get all Elements");
        }

        public async Task<IDataResult<EducationListDto>> GetAllByNonDelete()
        {
            var educations = await _unitOfWork.Education.GetAllAsync(x=>x.IsDeleted==false);
            if (educations.Count > 0)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success, new EducationListDto { Education = educations });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error, null, "Error,Failed to get all Elements");
        }

        public async Task<IDataResult<EducationListDto>> GetAllByNonDeleteAndActive()
        {
            var educations = await _unitOfWork.Education.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (educations.Count > 0)
            {
                return new DataResult<EducationListDto>(ResultStatus.Success, new EducationListDto { Education = educations });
            }
            return new DataResult<EducationListDto>(ResultStatus.Error, null, "Error,Failed to get all Elements");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var education = await _unitOfWork.Education.GetAsync(x => x.ID == id);
            if(education!=null)
            {
                await _unitOfWork.Education.DeleteAsync(education);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,Failed to Delete");
        }

        public async Task<IDataResult<EducationDto>> Update(EducationUpdateDto educationUpdateDto)
        {
           if(educationUpdateDto!=null)
            {
                var education = _mapper.Map<Education>(educationUpdateDto);
                await _unitOfWork.Education.UpdateAsync(education);
                education.CreatedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<EducationDto>(ResultStatus.Success, new EducationDto { Education = education });
            }
            return new DataResult<EducationDto>(ResultStatus.Error, null, "Error,Failed to Update");
        }
    }
}
