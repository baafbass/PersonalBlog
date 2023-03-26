using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SummaryDtos;
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
    public class SummaryService : ISummaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SummaryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<SummaryDto>> GetAsync(int Id)
        {
            var summary = await _unitOfWork.Summary.GetAsync(x => x.ID == Id);

            if(summary != null)
            {
                return new DataResult<SummaryDto>(ResultStatus.Success, new SummaryDto { Summary = summary });
            }
            return new DataResult<SummaryDto>(ResultStatus.Error,null,"Error, It was not Found!");
        }

        public async Task<IDataResult<SummaryDto>> UpdateAsync(SummaryUpdateDto summaryUpdateDto)
        {
            if(summaryUpdateDto != null)
            {
                var summary = _mapper.Map<Summary>(summaryUpdateDto);
                await _unitOfWork.Summary.UpdateAsync(summary);
                await _unitOfWork.SaveAsync();
                return new DataResult<SummaryDto>(ResultStatus.Success, new SummaryDto { Summary = summary });
            }
            return new DataResult<SummaryDto>(ResultStatus.Error,null,"Error,check the information you put");
        }
    }
}
