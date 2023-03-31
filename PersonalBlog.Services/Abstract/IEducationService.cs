using PersonalBlog.Entities.Dtos.EducationDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IEducationService
    {
        Task<IDataResult<EducationDto>> Get(int id);
        Task<IDataResult<EducationListDto>> GetAll();
        Task<IDataResult<EducationListDto>> GetAllByNonDelete();
        Task<IDataResult<EducationListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<EducationDto>> Add(EducationAddDto educationAddDto);
        Task<IDataResult<EducationDto>> Update(EducationUpdateDto educationUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
