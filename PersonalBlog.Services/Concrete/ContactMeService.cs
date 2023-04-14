using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ContactMeDtos;
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
    public class ContactMeService : IContactMeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactMeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<ContactMeDto>> Add(ContactMeAddDto contactMeAddDto, string createdByName)
        {
            var message = _mapper.Map<ContactMe>(contactMeAddDto);
            message.CreatedTime = DateTime.Now;
            message.ModifiedByName = createdByName;
            message.ModifiedByName = createdByName;
            var addedMessage = await _unitOfWork.ContactMe.AddAsync(message);
            await _unitOfWork.SaveAsync();
            return new DataResult<ContactMeDto>(ResultStatus.Success, 
                new ContactMeDto 
                {
                    ContactMe = addedMessage,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Message with {addedMessage.Subject} subject was successfully added !"
                }, $"The Message with {addedMessage.Subject} subject was successfully added !");
        }

        public async Task<IResult> CheckMessage(int messageId, string modifiedByName)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == messageId);
            if(message!=null)
            {
                message.IsActive = true;
                message.IsDeleted = true;
                message.ModifiedByName = modifiedByName;
                message.ModifiedTime = DateTime.Now;
                await _unitOfWork.ContactMe.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Message with {message.Subject} SUBJECT was successfully Checked !");
            }
            return new Result(ResultStatus.Error, "Error,The Message was not found");
        }
        public async Task<IResult> Delete(int messageId,string modifiedByName)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == messageId);
            if(message!=null)
            {
                message.IsDeleted = true;
                message.ModifiedByName = modifiedByName;
                message.ModifiedTime = DateTime.Now;
                await _unitOfWork.ContactMe.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Message with {message.Subject} Subject was successfully Deleted ! ");
            }
            return new Result(ResultStatus.Error, "Error, No record is found");
        }

        public async Task<IDataResult<ContactMeDto>> Get(int messageId)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == messageId);
          if(message!=null)
            {
                return new DataResult<ContactMeDto>(ResultStatus.Success, 
                    new ContactMeDto 
                    {
                        ContactMe = message,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<ContactMeDto>(ResultStatus.Error, new ContactMeDto
            {
                 ContactMe = null,
                 ResultStatus = ResultStatus.Error,
                 Info = "There is no such as element"
            }, "There is no such element");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAll()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync();
            if(messages.Count >-1)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success,
                    new ContactMeListDto
                    {
                        ContactMe = messages,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto
            { 
             ContactMe = null,
             ResultStatus = ResultStatus.Error,
             Info = "Failed to List the Whole elements"
            }, "Failed to List the whole elements");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAllByNonDelete()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync(x=>x.IsDeleted==false);
            if (messages.Count > -1)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success,
                    new ContactMeListDto
                    {
                        ContactMe = messages,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto
            {
                ContactMe = null,
                ResultStatus = ResultStatus.Error,
                Info = "Failed to List the Whole elements"
            }, "Failed to List the whole elements");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAllByNonDeleteAndActive()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (messages.Count > -1)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success,
                    new ContactMeListDto
                    {
                        ContactMe = messages,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto
            {
                ContactMe = null,
                ResultStatus = ResultStatus.Error,
                Info = "Failed to List the Whole elements"
            }, "Failed to List the whole elements");
        }

        public async Task<IDataResult<ContactMeUpdateDto>> GetUpdateDto(int messageId)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == messageId);
            if(message!=null)
            {
                var updateMessageDto = _mapper.Map<ContactMeUpdateDto>(message);
                return new DataResult<ContactMeUpdateDto>(ResultStatus.Success, updateMessageDto);
            }
            return new DataResult<ContactMeUpdateDto>(ResultStatus.Error, null,"Error,Element was not Found");
        }

        public async Task<IResult> HardDelete(int messageId)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == messageId);
            if(message!=null)
            {
                await _unitOfWork.ContactMe.DeleteAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Message with the {message.Subject} was successfully Deleted ");
            }
            return new Result(ResultStatus.Error, "Failed to Delete");
        }

        public async Task<IDataResult<ContactMeDto>> Update(ContactMeUpdateDto contactMeUpdateDto,string modifiedByName)
        {
            
                var message = _mapper.Map<ContactMe>(contactMeUpdateDto);
                message.ModifiedTime = DateTime.Now;
                message.ModifiedByName = modifiedByName;
                var updatedMessage = await _unitOfWork.ContactMe.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new DataResult<ContactMeDto>(ResultStatus.Success, 
                    new ContactMeDto 
                    {
                        ContactMe = updatedMessage,
                        Info = $"The Message with the {updatedMessage.Subject} Subject was successfully Updated ! ",
                        ResultStatus = ResultStatus.Success
                    }, $"The Message with the {updatedMessage.Subject} Subject was successfully Updated ! ");
        }
    }
}
