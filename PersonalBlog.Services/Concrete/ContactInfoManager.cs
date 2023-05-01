using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities;
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
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactInfoManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IResult> Delete(int contactInfoId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ContactInfoDto>> Get(int contactId = 1)
        {
            var info = await _unitOfWork.ContactInfo.GetAsync(x => x.ID == contactId);
            if(info!=null)
            {
                return new DataResult<ContactInfoDto>(ResultStatus.Success, 
                    new ContactInfoDto 
                    {
                        ContactInfo = info,
                        ResultStatus = ResultStatus.Success,
                    });
            }
            return new DataResult<ContactInfoDto>(ResultStatus.Error,
                new ContactInfoDto
                {
                    ContactInfo = null,
                    ResultStatus = ResultStatus.Error,
                    Info = "Error,No Record is Found"
                }, "Error, No record is found");
        }

        public async Task<IDataResult<ContactInfoUpdateDto>> GetUpdateDto(int ContactInfoId)
        {
            var contact = await _unitOfWork.ContactInfo.GetAsync(x => x.ID == ContactInfoId);
            if(contact !=null)
            {
                var updateInfoDto = _mapper.Map<ContactInfoUpdateDto>(contact);
                return new DataResult<ContactInfoUpdateDto>(ResultStatus.Success, updateInfoDto);
            }
            return new DataResult<ContactInfoUpdateDto>(ResultStatus.Error, null,"Error,The Element was Not found");
        }

        public Task<IResult> HardDelete(int ContactInfoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ContactInfoDto>> Update(ContactInfoUpdateDto contactInfoUpdateDto,string modifiedByName)
        {
                var info = _mapper.Map<ContactInfo>(contactInfoUpdateDto);
                info.ModifiedByName = modifiedByName;
                info.ModifiedTime = DateTime.Now;
                var updatedInfo = await _unitOfWork.ContactInfo.UpdateAsync(info);
                await _unitOfWork.SaveAsync();
                return new DataResult<ContactInfoDto>(ResultStatus.Success,
                    new ContactInfoDto
                    {
                        ContactInfo = updatedInfo,
                        ResultStatus = ResultStatus.Success
                    });
        }
    }
}
