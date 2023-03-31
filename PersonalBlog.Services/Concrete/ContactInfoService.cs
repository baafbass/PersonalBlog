using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Services.Abstract;
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
    public class ContactInfoService : IContactInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactInfoService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ContactInfoDto>> Get(int id)
        {
            var info = await _unitOfWork.ContactInfo.GetAsync(x => x.ID == id);
            if(info!=null)
            {
                return new DataResult<ContactInfoDto>(ResultStatus.Success, new ContactInfoDto { ContactInfo = info });
            }
            return new DataResult<ContactInfoDto>(ResultStatus.Error, null, "Error, No record is found");
        }

        public async Task<IDataResult<ContactInfoDto>> Update(ContactInfoUpdateDto contactInfoUpdateDto)
        {
            if(contactInfoUpdateDto!=null)
            {
                var info = _mapper.Map<ContactInfo>(contactInfoUpdateDto);
                await _unitOfWork.ContactInfo.UpdateAsync(info);
                info.ModifiedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<ContactInfoDto>(ResultStatus.Success, new ContactInfoDto { ContactInfo = info });
            }
            return new DataResult<ContactInfoDto>(ResultStatus.Error, null, "No record is found");
        }
    }
}
