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
        Task<IDataResult<ContactMeDto>> Get(int messageId);
        Task<IDataResult<ContactMeUpdateDto>> GetUpdateDto(int messageId);
        Task<IDataResult<ContactMeListDto>> GetAll();
        Task<IDataResult<ContactMeListDto>> GetAllByNonDelete();
        Task<IDataResult<ContactMeListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ContactMeDto>> Add(ContactMeAddDto contactMeAddDto,string createdByName);
        Task<IDataResult<ContactMeDto>> Update(ContactMeUpdateDto contactMeUpdateDto,string modifiedByName);
        Task<IResult> CheckMessage (int messageId,string modifiedByName);
        Task<IResult> Delete(int messageId,string modifiedByName);
        Task<IResult> HardDelete(int id);
    }
}
