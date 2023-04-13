using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IContactInfoService
    {
        Task<IDataResult<ContactInfoDto>> Get(int ContactInfoId);
        Task<IDataResult<ContactInfoUpdateDto>> GetUpdateDto(int ContactInfoId);
        Task<IDataResult<ContactInfoDto>> Update(ContactInfoUpdateDto contactInfoUpdateDto,string modifiedByName);
        Task<IResult> Delete(int ContactInfoId,string modifiedByName);
        Task<IResult> HardDelete(int ContactInfoId);
    }
}
