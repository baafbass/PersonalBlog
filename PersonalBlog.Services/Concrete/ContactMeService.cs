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
        public async Task<IDataResult<ContactMeDto>> Add(ContactMeAddDto contactMeAddDto)
        {
            if(contactMeAddDto != null)
            {
                var message = _mapper.Map<ContactMe>(contactMeAddDto);
                message.CreatedTime = DateTime.Now;
                await _unitOfWork.ContactMe.AddAsync(message);
                await _unitOfWork.SaveAsync();
                return new DataResult<ContactMeDto>(ResultStatus.Success, new ContactMeDto { ContactMe = message }); 
            }
            return new DataResult<ContactMeDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == id);
            if(message!=null)
            {
                message.IsDeleted = true;
                await _unitOfWork.ContactMe.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, No record is found");
        }

        public async Task<IDataResult<ContactMeDto>> Get(int id)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == id);
          if(message!=null)
            {
                return new DataResult<ContactMeDto>(ResultStatus.Success, new ContactMeDto { ContactMe = message });
            }
            return new DataResult<ContactMeDto>(ResultStatus.Error, null, "There is no such element");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAll()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync();
            if(messages.Count >0)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto { ContactMe = messages });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, null, "Failed to the whole elements");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAllByNonDelete()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync(x=>x.IsDeleted==false);
            if (messages.Count > 0)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto { ContactMe = messages });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, null, "Failed to list the whole elements");
        }

        public async Task<IDataResult<ContactMeListDto>> GetAllByNonDeleteAndActive()
        {
            var messages = await _unitOfWork.ContactMe.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (messages.Count > 0)
            {
                return new DataResult<ContactMeListDto>(ResultStatus.Success, new ContactMeListDto { ContactMe = messages });
            }
            return new DataResult<ContactMeListDto>(ResultStatus.Success, null, "Failed to list the whole elements");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var message = await _unitOfWork.ContactMe.GetAsync(x => x.ID == id);
            if(message!=null)
            {
                await _unitOfWork.ContactMe.DeleteAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Failed to Delete");
        }

        public async Task<IDataResult<ContactMeDto>> Update(ContactMeUpdateDto contactMeUpdateDto)
        {
            if(contactMeUpdateDto!=null)
            {
                var message = _mapper.Map<ContactMe>(contactMeUpdateDto);
                message.ModifiedTime = DateTime.Now;
                await _unitOfWork.ContactMe.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new DataResult<ContactMeDto>(ResultStatus.Success, new ContactMeDto { ContactMe = message });
            }
            return new DataResult<ContactMeDto>(ResultStatus.Error, null, "Failed To Update");
        }
    }
}
