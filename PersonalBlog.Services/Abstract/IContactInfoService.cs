using PersonalBlog.Entities.Dtos.ContactInfoDtos;
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
        Task<IDataResult<ContactInfoDto>> Get(int id);
        Task<IDataResult<ContactInfoDto>> Update(ContactInfoUpdateDto contactInfoUpdateDto);
    }
}
