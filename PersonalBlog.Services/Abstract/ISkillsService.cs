using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ISkillsService
    {
        Task<IDataResult<SkillsDto>> Get(int id);
        Task<IDataResult<SkillsListDto>> GetAll();
        Task<IDataResult<SkillsListDto>> GetAllByNonDelete();
        Task<IDataResult<SkillsListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SkillsDto>> Add(SkillsAddDto skillsAddDto);
        Task<IDataResult<SkillsDto>> Update(SkillsUpdateDto skillsUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
