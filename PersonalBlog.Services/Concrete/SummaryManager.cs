using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SummaryDtos;
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
    public class SummaryManager : ISummaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SummaryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Delete(int summaryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<SummaryDto>> Get(int summaryId=1)
        {
            var summary = await _unitOfWork.Summary.GetAsync(x => x.ID == summaryId);

            if(summary != null)
            {
                return new DataResult<SummaryDto>(ResultStatus.Success,
                    new SummaryDto 
                    {
                        Summary = summary,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<SummaryDto>(ResultStatus.Error,new SummaryDto 
            {
             ResultStatus = ResultStatus.Error,
             Info = "Error,It was not Found !",
             Summary = null
            },"Error, It was not Found!");
        }

        public async Task<IDataResult<SummaryUpdateDto>> GetUpdateDto(int summaryId)
        {
            var summary = await _unitOfWork.Summary.GetAsync(x => x.ID == summaryId);
            if (summary != null)
            {
                var summaryUpdateDto = _mapper.Map<SummaryUpdateDto>(summary);
                return new DataResult<SummaryUpdateDto>(ResultStatus.Success, summaryUpdateDto);
            }
            return new DataResult<SummaryUpdateDto>(ResultStatus.Error,null, "Error,No Record is found !");
        }

        public async Task<IResult> HardDelete(int summaryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<SummaryDto>> Update(SummaryUpdateDto summaryUpdateDto,string modifiedByName)
        {
                var summary = _mapper.Map<Summary>(summaryUpdateDto);
                summary.ModifiedByName = modifiedByName;
                summary.ModifiedTime = DateTime.Now; 
                var updatedSummary = await _unitOfWork.Summary.UpdateAsync(summary);
                await _unitOfWork.SaveAsync();
                return new DataResult<SummaryDto>(ResultStatus.Success,
                    new SummaryDto 
                   { 
                        Summary = updatedSummary,
                        ResultStatus = ResultStatus.Success,
                        Info = "The Summary was update successfully updated !"
                    }, "The Summary was update successfully updated !");
        }
    }
}
