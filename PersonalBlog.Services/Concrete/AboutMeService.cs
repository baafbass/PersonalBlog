using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.AboutMeDtos;
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
    public class AboutMeService : IAboutMeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutMeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AboutMeDto>> Get(int id)
        {
            var aboutMe = await _unitOfWork.AboutMe.GetAsync(x => x.ID == id);
            if(aboutMe!=null)
            {
                return new DataResult<AboutMeDto>(ResultStatus.Success, new AboutMeDto { AboutMe = aboutMe });
            }
            return new DataResult<AboutMeDto>(ResultStatus.Error, null, "Error,NO record is found");
        }

        public async Task<IDataResult<AboutMeDto>> Update(AboutMeUpdateDto aboutMeUpdateDto)
        {
            if(aboutMeUpdateDto!=null)
            {
                var aboutMe = _mapper.Map<AboutMe>(aboutMeUpdateDto);
                await _unitOfWork.AboutMe.UpdateAsync(aboutMe);
                aboutMe.ModifiedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<AboutMeDto>(ResultStatus.Success, new AboutMeDto { AboutMe = aboutMe });
            }
            return new DataResult<AboutMeDto>(ResultStatus.Error, null, "Failed to Update");
        }
    }
}
