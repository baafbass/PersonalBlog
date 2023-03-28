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
        public async Task<IDataResult<SlidersDto>> Add(SlidersAddDto slidersAddDto)
        {
            if(slidersAddDto != null)
            {
                var slider = _mapper.Map<HomePageSliders>(slidersAddDto);
                await _unitOfWork.HomePageSliders.AddAsync(slider);
                await _unitOfWork.SaveAsync();
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto { Sliders = slider });
            }
            return new DataResult<SlidersDto>(ResultStatus.Error, null, "Error, Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var Slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == id);
            if(Slider!=null)
            {
                Slider.IsDeleted = true;
                await _unitOfWork.HomePageSliders.UpdateAsync(Slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,No such as element is found");
        }

        public async Task<IDataResult<SlidersDto>> Get(int id)
        {
            var slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == id);
            if(slider != null)
            {
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto { Sliders = slider });
            }
            return new DataResult<SlidersDto>(ResultStatus.Error, null, "Error, No record found");
        }

        public async Task<IDataResult<SlidersListDto>> GetAll()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync();
            if(sliders.Count>0)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success);
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, null, "Such as records are not found");
        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDelete()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync(x=>x.IsDeleted==false);
            if (sliders.Count > 0)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success);
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, null, "Such as records are not found");

        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDeleteAndActive()
        {
            var sliders = await _unitOfWork.HomePageSliders.GetAllAsync(x => x.IsDeleted == false && x.IsActive==true);
            if (sliders.Count > 0)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success);
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, null, "Such as records are not found");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var slider = await _unitOfWork.HomePageSliders.GetAsync(x => x.ID == id);
            if(slider!=null)
            {
                await _unitOfWork.HomePageSliders.DeleteAsync(slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "There is no such a element");
        }

        public async Task<IDataResult<SlidersDto>> Update(SlidersUpdateDto slidersUpdateDto)
        {
            if(slidersUpdateDto!=null)
            {
                var slider = _mapper.Map<HomePageSliders>(slidersUpdateDto);
                slider.ModifiedTime = DateTime.Now;
                await _unitOfWork.HomePageSliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto { Sliders = slider });
            }
            return new DataResult<SlidersDto>(ResultStatus.Error, null, "Failed to Update");
        }
    }
}
