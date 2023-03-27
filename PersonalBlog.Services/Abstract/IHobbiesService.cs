using PersonalBlog.Entities.Dtos.HobbiesDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IHobbiesService
    {
        Task<IDataResult<HobbiesDto>> Get(int id);
        Task<IDataResult<HobbiesListDtos>> GetAll();
        Task<IDataResult<HobbiesListDtos>> GetAllByNonDelete();
        Task<IDataResult<HobbiesListDtos>> GetAllByNonDeleteAndActive();
        Task<IDataResult<HobbiesDto>> Add(HobbiesAddDtos hobbiesAddDtos);
        Task<IDataResult<HobbiesDto>> Update(HobbiesUpdateDtos hobbiesUpdateDtos);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
