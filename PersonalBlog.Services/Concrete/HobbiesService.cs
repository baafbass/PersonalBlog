using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
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
    public class HobbiesService : IHobbiesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HobbiesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<HobbiesDto>> Add(HobbiesAddDtos hobbiesAddDtos)
        {
            if(hobbiesAddDtos != null)
            {
                var hobby =  _mapper.Map<Hobbies>(hobbiesAddDtos);
                await _unitOfWork.Hobbies.AddAsync(hobby);
                hobby.CreatedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<HobbiesDto>(ResultStatus.Success, new HobbiesDto { Hobbies = hobby });
            }
            return new DataResult<HobbiesDto>(ResultStatus.Error, null, "Error, failed to register");
            
        }

        public async Task<IResult> Delete(int id)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x => x.ID == id);
            
            if(hobby!=null)
            {
                hobby.IsDeleted = true;
                await _unitOfWork.Hobbies.UpdateAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "No record found");
        }

        public async Task<IDataResult<HobbiesDto>> Get(int id)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x => x.ID == id);
            if(hobby!=null)
            {
                return new DataResult<HobbiesDto>(ResultStatus.Success, new HobbiesDto { Hobbies = hobby });
            }
            return new DataResult<HobbiesDto>(ResultStatus.Error,null,"The element was not found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAll()
        {
            var hobbyList = await _unitOfWork.Hobbies.GetAllAsync();
            if(hobbyList.Count > 0)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success, new HobbiesListDtos { Hobbies = hobbyList });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, null, "Error, No records are found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAllByNonDelete()
        {
            var hobbies = await _unitOfWork.Hobbies.GetAllAsync(x=> x.IsDeleted == false);
            
            if(hobbies.Count > 0)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success, new HobbiesListDtos { Hobbies = hobbies });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, null, "Error,No records are found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAllByNonDeleteAndActive()
        {
            var hobbies = await _unitOfWork.Hobbies.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);

            if (hobbies.Count > 0)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success, new HobbiesListDtos { Hobbies = hobbies });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, null, "Error,No records are found");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x=>x.ID == id);

            if(hobby!=null)
            {
                await _unitOfWork.Hobbies.DeleteAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error,"Error, failed to delete");
        }

        public async Task<IDataResult<HobbiesDto>> Update(HobbiesUpdateDtos hobbiesUpdateDtos)
        {
            if(hobbiesUpdateDtos!=null)
            {
                var hobby = _mapper.Map<Hobbies>(hobbiesUpdateDtos);
                await _unitOfWork.Hobbies.UpdateAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new DataResult<HobbiesDto>(ResultStatus.Success, new HobbiesDto { Hobbies = hobby });
            }
            return new DataResult<HobbiesDto>(ResultStatus.Error, null, "Error, failed to Update");
        }
    }
}
