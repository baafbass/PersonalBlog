using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SiteDtos;
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
    public class SiteService : ISiteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SiteService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Delete(int siteId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<SiteDto>> Get(int SiteId = 1)
        {
            var siteIdentity = await _unitOfWork.Site.GetAsync(x => x.ID == SiteId);
            if(siteIdentity!=null)
            {
                return new DataResult<SiteDto>(ResultStatus.Success, 
                    new SiteDto 
                    {
                        Site = siteIdentity,
                        ResultStatus= ResultStatus.Success
                    });
            }
            return new DataResult<SiteDto>(ResultStatus.Error, new SiteDto
            {
             ResultStatus = ResultStatus.Error,
             Site =null,
             Info ="No record is found"
            }, "No record is found");
        }

        public async Task<IDataResult<SiteUpdateDto>> GetUpdateDto(int SiteId=1)
        {
            var identity = await _unitOfWork.Site.GetAsync(x => x.ID == SiteId);
            if(identity!=null)
            {
                var updateSiteDto = _mapper.Map<SiteUpdateDto>(identity);
                return new DataResult<SiteUpdateDto>(ResultStatus.Success, updateSiteDto);
            }
            return new DataResult<SiteUpdateDto>(ResultStatus.Error, null, "Error, Failed to be Found");
        }

        public async Task<IResult> HardDelete(int siteId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<SiteDto>> Update(SiteUpdateDto siteUpdateDto,string modifiedByName)
        {
                var siteUpdates = _mapper.Map<Site>(siteUpdateDto);
                siteUpdates.ModifiedByName = modifiedByName;
                siteUpdates.ModifiedTime = DateTime.Now;
                var updatedSite = await _unitOfWork.Site.UpdateAsync(siteUpdates);
                await _unitOfWork.SaveAsync();
                return new DataResult<SiteDto>(ResultStatus.Success, new SiteDto 
                {
                    Site = updatedSite,
                    ResultStatus = ResultStatus.Success,
                    Info= "Site credentials updated successfully"
                }, "Site credentials updated successfully");
        }
    }
}
