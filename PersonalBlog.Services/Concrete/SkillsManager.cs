using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Entities.Dtos.SlidersDtos;
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
    public class SkillsManager : ISkillsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillsManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IDataResult<SkillsDto>> Add(SkillsAddDto skillsAddDto,string createdByName)
        {
                var skill = _mapper.Map<Skills>(skillsAddDto);
                skill.CreatedTime = DateTime.Now;
                skill.ModifiedByName = createdByName;
                skill.CreatedByName = createdByName;
                await _unitOfWork.Skills.AddAsync(skill);
                await _unitOfWork.SaveAsync();
                return new DataResult<SkillsDto>(ResultStatus.Success, new SkillsDto 
                {
                    Skills = skill,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Skill {skill.SkillName} was successfully Added !"
                });
        }

        public async Task<IResult> Delete(int skillId,string modifiedByName)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == skillId);
            if(skill!=null)
            {
                skill.IsDeleted = true;
                skill.ModifiedByName = modifiedByName;
                skill.ModifiedTime = DateTime.Now;
                await _unitOfWork.Skills.UpdateAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Skill {skill.SkillName} was successfully Deleted !");
            }
            return new Result(ResultStatus.Error, "Error,There is no such as element");
        }

        public async Task<IDataResult<SkillsDto>> Get(int skillId)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == skillId);
            if(skill!=null)
            {
                return new DataResult<SkillsDto>(ResultStatus.Success, 
                    new SkillsDto { 
                        Skills = skill,
                        ResultStatus = ResultStatus.Error
                    });
            }
            return new DataResult<SkillsDto>(ResultStatus.Error, 
                new SkillsDto 
                { 
                 Skills =null,
                 ResultStatus =ResultStatus.Error,
                 Info = "No Record is found"
                }, "No record is found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAll()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync();
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success,
                    new SkillsListDto
                    {
                        Skills = skills,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error,
                new SkillsListDto
                {
                    ResultStatus = ResultStatus.Error,
                    Skills = null,
                    Info = "No such Elements are found"
                }, "No elements are found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDelete()
        {

            var skills = await _unitOfWork.Skills.GetAllAsync(x=>x.IsDeleted==false);
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success,
                    new SkillsListDto
                    {
                        Skills = skills,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error,
                new SkillsListDto
                {
                    ResultStatus = ResultStatus.Error,
                    Skills = null,
                    Info = "No such Elements are found"
                }, "No elements are found");
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDeleteAndActive()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, 
                    new SkillsListDto 
                    {
                        Skills = skills,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, 
                new SkillsListDto
                {
                 ResultStatus = ResultStatus.Error,
                 Skills = null,
                 Info = "No such Elements are found"
                }, "No elements are found");
        }

        public async Task<IDataResult<SkillsUpdateDto>> GetUpdateDto(int skillId)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == skillId);
            if(skill != null)
            {
                var updateSkillDto = _mapper.Map<SkillsUpdateDto>(skill);
                return new DataResult<SkillsUpdateDto>(ResultStatus.Success, updateSkillDto);
            }
            return new DataResult<SkillsUpdateDto>(ResultStatus.Error, null, "Failed to Get The Skill");
        }

        public async Task<IResult> HardDelete(int skillId)
        {
            var skill = await _unitOfWork.Skills.GetAsync(x => x.ID == skillId);
            if(skill!=null)
            {
                await _unitOfWork.Skills.DeleteAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Skill {skill.SkillName} Was successfully Deleted !");
            }
            return new Result(ResultStatus.Error,"Error, Deletion is failed");
        }

        public async Task<IDataResult<SkillsDto>> Update(SkillsUpdateDto skillsUpdateDto,string modifiedByName)
        {
                var skill = _mapper.Map<Skills>(skillsUpdateDto);
                skill.ModifiedByName = modifiedByName;
                skill.ModifiedTime = DateTime.Now;
                var updatedSkill = await _unitOfWork.Skills.UpdateAsync(skill);
                await _unitOfWork.SaveAsync();
                return new DataResult<SkillsDto>(ResultStatus.Success, 
                    new SkillsDto
                    {
                        Skills = updatedSkill,
                        ResultStatus = ResultStatus.Success,
                        Info = $"The Skill {updatedSkill.SkillName} was successfully Updated !"
                    });
        }
    }
}
