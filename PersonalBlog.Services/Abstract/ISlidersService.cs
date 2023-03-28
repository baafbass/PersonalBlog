using PersonalBlog.Entities.Dtos;
using PersonalBlog.Entities.Dtos.SlidersDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ISlidersService
    {
        Task<IDataResult<SlidersDto>> Get(int id);
        Task<IDataResult<SlidersListDto>> GetAll();
        Task<IDataResult<SlidersListDto>> GetAllByNonDelete();
        Task<IDataResult<SlidersListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SlidersDto>> Add(SlidersAddDto slidersAddDto);
        Task<IDataResult<SlidersDto>> Update(SlidersUpdateDto slidersUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
