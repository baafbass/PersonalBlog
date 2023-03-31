using PersonalBlog.Entities.Dtos.ContactMeDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IContactMeService
    {
        Task<IDataResult<ContactMeDto>> Get(int id);
        Task<IDataResult<ContactMeListDto>> GetAll();
        Task<IDataResult<ContactMeListDto>> GetAllByNonDelete();
        Task<IDataResult<ContactMeListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ContactMeDto>> Add(ContactMeAddDto contactMeAddDto);
        Task<IDataResult<ContactMeDto>> Update(ContactMeUpdateDto contactMeUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
