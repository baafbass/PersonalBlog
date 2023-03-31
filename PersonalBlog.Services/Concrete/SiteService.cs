using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SiteDtos;
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
    public class SiteService : ISiteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SiteService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<SiteDto>> Get(int id)
        {
            var siteIdentity = await _unitOfWork.Site.GetAsync(x => x.ID == id);
            if(siteIdentity!=null)
            {
                return new DataResult<SiteDto>(ResultStatus.Success, new SiteDto { Site = siteIdentity });
            }
            return new DataResult<SiteDto>(ResultStatus.Error, null, "No record is found");
        }

        public async Task<IDataResult<SiteDto>> update(SiteUpdateDto siteUpdateDto)
        {
            if(siteUpdateDto!=null)
            {
                var siteUpdates = _mapper.Map<Site>(siteUpdateDto);
                await _unitOfWork.Site.UpdateAsync(siteUpdates);
                siteUpdates.ModifiedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<SiteDto>(ResultStatus.Success, new SiteDto { Site = siteUpdates });
            }
            return new DataResult<SiteDto>(ResultStatus.Error, null, "Failed to Update");
        }
    }
}
