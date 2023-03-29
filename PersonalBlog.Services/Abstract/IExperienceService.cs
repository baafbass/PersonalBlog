using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IExperienceService
    {
        Task<IDataResult<ExperiencesDto>> Get(int id);
        Task<IDataResult<ExperiencesListDto>> GetAll();
        Task<IDataResult<ExperiencesListDto>> GetAllByNonDelete();
        Task<IDataResult<ExperiencesListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ExperiencesDto>> Add(ExperiencesAddDto experiencesAddDto);
        Task<IDataResult<ExperiencesDto>> Update(ExperiencesUpdateDto experiencesUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
