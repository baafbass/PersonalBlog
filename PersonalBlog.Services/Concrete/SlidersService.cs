using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos;
using PersonalBlog.Entities.Dtos.SlidersDtos;
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
    public class SlidersService : ISlidersService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SlidersService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<SlidersUpdateDto>> GetUpdateDto(int sliderId)
        {
            var slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == sliderId);
            if (slider != null)
            {
                var updatedSliderDto = _mapper.Map<SlidersUpdateDto>(slider);
                return new DataResult<SlidersUpdateDto>(ResultStatus.Success, updatedSliderDto);
            }
            return new DataResult<SlidersUpdateDto>(ResultStatus.Error, null, "The SLIDER was not found");
        }

        public async Task<IDataResult<SlidersDto>> Add(SlidersAddDto slidersAddDto,string createdByName)
        {
            
                var slider = _mapper.Map<HomePageSliders>(slidersAddDto);
                slider.ModifiedByName = createdByName;
                slider.ModifiedTime = DateTime.Now;
                slider.CreatedByName = createdByName;
                var addedSlider = await _unitOfWork.HomePageSliders.AddAsync(slider);
                await _unitOfWork.SaveAsync();
            return new DataResult<SlidersDto>(ResultStatus.Success,
                new SlidersDto
                {
                    Sliders = addedSlider,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Slider {slider.Title} was Successfully Added !"
                },$"The Slider {slider.Title} was Successfully Added !") ;
        }

        public async Task<IResult> Delete(int sliderId,string modifiedByName)
        {
            var Slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == sliderId);
            if(Slider!=null)
            {
                Slider.IsDeleted = true;
                Slider.ModifiedByName = modifiedByName;
                Slider.CreatedTime = DateTime.Now;
                await _unitOfWork.HomePageSliders.UpdateAsync(Slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Slider {Slider.Title} was successfully Deleted !");
            }
            return new Result(ResultStatus.Error, "Error,No such as element is found");
        }

        public async Task<IDataResult<SlidersDto>> Get(int sliderId)
        {
            var slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == sliderId);
            if(slider != null)
            {
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto 
                {
                    Sliders = slider,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SlidersDto>(ResultStatus.Error, new SlidersDto
            {
                ResultStatus =ResultStatus.Error,
                Sliders =null,
                Info = "No record is found"
            }, "Error, No record is found");
        }

        public async Task<IDataResult<SlidersListDto>> GetAll()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync();
            if(sliders.Count>-1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, new SlidersListDto 
            {
                ResultStatus = ResultStatus.Error,
                Info = "No such as records are found",
                Sliders = null
            }, "Such as records are not found");
        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDelete()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync(x=>x.IsDeleted==false);
            if (sliders.Count > -1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, new SlidersListDto
            {
                ResultStatus = ResultStatus.Error,
                Info = "No such as records are found",
                Sliders = null
            }, "Such as records are not found");

        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDeleteAndActive()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (sliders.Count > -1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, new SlidersListDto
            {
                ResultStatus = ResultStatus.Error,
                Info = "No such as records are found",
                Sliders = null
            }, "Such as records are not found");
        }

        public async Task<IResult> HardDelete(int sliderId)
        {
            var slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == sliderId);
            if(slider!=null)
            {
                await _unitOfWork.HomePageSliders.DeleteAsync(slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Slider {slider.Title} was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "There is no such a element");
        }

        public async Task<IDataResult<SlidersDto>> Update(SlidersUpdateDto slidersUpdateDto,string modifiedByName)
        {
                var slider = _mapper.Map<HomePageSliders>(slidersUpdateDto);
                slider.ModifiedTime = DateTime.Now;
                slider.ModifiedByName = modifiedByName;
                var updatedSlider = await _unitOfWork.HomePageSliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto 
                {
                    Sliders = updatedSlider,
                    ResultStatus = ResultStatus.Success,
                    Info = $"The Slider {slider.Title} was successfully Deleted ! "
                });
        }
    }
}
