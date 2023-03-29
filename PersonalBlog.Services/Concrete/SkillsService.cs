using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SkillsDtos;
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
    public class SkillsService : ISkillsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillsService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<SkillsDto>> Add(SkillsAddDto skillsAddDto)
        {
           if(skillsAddDto!=null)
            {
                var skill = _mapper.Map<Skills>(skillsAddDto);
                skill.CreatedTime = DateTime.Now;
                await _unitOfWork.Skills.AddAsync(skill);
                await _unitOfWork.SaveAsync();
                return new DataResult<SkillsDto>(ResultStatus.Success, new SkillsDto { Skills = skill });
            }
            return new DataResult<SkillsDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == id);
            if(skill!=null)
            {
                skill.IsDeleted = true;
                await _unitOfWork.Skills.UpdateAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,There is no such as element");
        }

        public async Task<IDataResult<SkillsDto>> Get(int id)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == id);
            if(skill!=null)
            {
                return new DataResult<SkillsDto>(ResultStatus.Success, new SkillsDto { Skills = skill });
            }
            return new DataResult<SkillsDto>(ResultStatus.Error, null, "No record is found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAll()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync();
            if(skills.Count>0)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto { Skills = skills });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, null, "No elements are found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDelete()
        {

            var skills = await _unitOfWork.Skills.GetAllAsync(x=>x.IsDeleted==false);
            if (skills.Count > 0)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto { Skills = skills });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, null, "No elements are found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDeleteAndActive()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (skills.Count > 0)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto { Skills = skills });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, null, "No elements are found");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == id);
            if(skill!=null)
            {
                await _unitOfWork.Skills.DeleteAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error,"Error, Deletion is failed");
        }

        public async Task<IDataResult<SkillsDto>> Update(SkillsUpdateDto skillsUpdateDto)
        {
            if(skillsUpdateDto!=null)
            {
                var skill = _mapper.Map<Skills>(skillsUpdateDto);
                skill.ModifiedTime = DateTime.Now;
                await _unitOfWork.Skills.UpdateAsync(skill);
                await _unitOfWork.SaveAsync();
                return new DataResult<SkillsDto>(ResultStatus.Success, new SkillsDto { Skills = skill });
            }
            return new DataResult<SkillsDto>(ResultStatus.Error, null, "Error, Failed to Update");
        }
    }
}
