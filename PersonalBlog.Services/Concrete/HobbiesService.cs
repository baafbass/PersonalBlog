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

        public async Task<IDataResult<HobbiesDto>> Add(HobbiesAddDtos hobbiesAddDtos,string createdByName)
        {  
                var hobby =  _mapper.Map<Hobbies>(hobbiesAddDtos);
                hobby.CreatedTime = DateTime.Now;
                hobby.ModifiedByName = createdByName;
                hobby.CreatedByName = createdByName;
               var addedHobby = await _unitOfWork.Hobbies.AddAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new DataResult<HobbiesDto>(ResultStatus.Success, 
                    new HobbiesDto
                    {
                        Hobbies = addedHobby,
                        ResultStatus = ResultStatus.Success,
                        Info = $"The Hobby {hobby.hobbies} was successfully  added ! "
                    });
        }

        public async Task<IResult> Delete(int hobbyId,string modifiedByName)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x => x.ID == hobbyId);
            
            if(hobby!=null)
            {
                hobby.IsDeleted = true;
                hobby.ModifiedByName = modifiedByName;
                hobby.ModifiedTime = DateTime.Now;
                await _unitOfWork.Hobbies.UpdateAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Hobby {hobby.hobbies} was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "No record found");
        }

        public async Task<IDataResult<HobbiesDto>> Get(int hobbyId)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x => x.ID == hobbyId);
            if(hobby!=null)
            {
                return new DataResult<HobbiesDto>(ResultStatus.Success, 
                    new HobbiesDto 
                    {
                        Hobbies = hobby,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<HobbiesDto>(ResultStatus.Error,
                new HobbiesDto
                { 
                    Hobbies = null,
                    ResultStatus = ResultStatus.Error,
                    Info = "Error,Failed To Get the element"
                },"The element was not found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAll()
        {
            var hobbyList = await _unitOfWork.Hobbies.GetAllAsync();
            if(hobbyList.Count > -1)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success,
                    new HobbiesListDtos
                    { 
                        Hobbies = hobbyList,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, new HobbiesListDtos
            { 
              Hobbies =null,
              ResultStatus =ResultStatus.Error,
              Info = "Error, No Such as records are found"
            }, "Error, No records are found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAllByNonDelete()
        {
            var hobbyList = await _unitOfWork.Hobbies.GetAllAsync(x=> x.IsDeleted == false);

            if (hobbyList.Count > -1)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success,
                    new HobbiesListDtos
                    {
                        Hobbies = hobbyList,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, new HobbiesListDtos
            {
                Hobbies = null,
                ResultStatus = ResultStatus.Error,
                Info = "Error, No Such as records are found"
            }, "Error, No records are found");
        }

        public async Task<IDataResult<HobbiesListDtos>> GetAllByNonDeleteAndActive()
        {
            var hobbyList = await _unitOfWork.Hobbies.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (hobbyList.Count > -1)
            {
                return new DataResult<HobbiesListDtos>(ResultStatus.Success,
                    new HobbiesListDtos
                    {
                        Hobbies = hobbyList,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<HobbiesListDtos>(ResultStatus.Error, new HobbiesListDtos
            {
                Hobbies = null,
                ResultStatus = ResultStatus.Error,
                Info = "Error, No Such as records are found"
            }, "Error, No records are found");
        }

        public async Task<IDataResult<HobbiesUpdateDtos>> GetUpdateDto(int hobbyId)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x => x.ID == hobbyId);
            if(hobby!=null)
            {
                var hobbyUpdateDto = _mapper.Map<HobbiesUpdateDtos>(hobby);
                return new DataResult<HobbiesUpdateDtos>(ResultStatus.Success, hobbyUpdateDto);
            }
            return new DataResult<HobbiesUpdateDtos>(ResultStatus.Error, null,"Error,It was not found");
        }

        public async Task<IResult> HardDelete(int hobbyId)
        {
            var hobby = await _unitOfWork.Hobbies.GetAsync(x=>x.ID == hobbyId);

            if(hobby!=null)
            {
                await _unitOfWork.Hobbies.DeleteAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The hobby {hobby.hobbies} was successfully Deleted ! ");
            }
            return new Result(ResultStatus.Error,"Error, failed to delete");
        }

        public async Task<IDataResult<HobbiesDto>> Update(HobbiesUpdateDtos hobbiesUpdateDtos,string modifiedByName)
        {
                var hobby = _mapper.Map<Hobbies>(hobbiesUpdateDtos);
                hobby.ModifiedByName = modifiedByName;
                hobby.ModifiedTime = DateTime.Now;
                var updatedHobby = await _unitOfWork.Hobbies.UpdateAsync(hobby);
                await _unitOfWork.SaveAsync();
                return new DataResult<HobbiesDto>(ResultStatus.Success, 
                    new HobbiesDto 
                    {
                        Hobbies = updatedHobby,
                        ResultStatus = ResultStatus.Success,
                        Info = $"The hobby {hobby.hobbies} was successfully Updated"
                    });
        }
    }
}
