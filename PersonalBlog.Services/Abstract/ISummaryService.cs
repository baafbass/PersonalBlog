using PersonalBlog.Entities.Dtos.SummaryDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ISummaryService
    {
        Task<IDataResult<SummaryDto>> Get(int summaryId);
        Task<IDataResult<SummaryUpdateDto>> GetUpdateDto(int summaryId);
        Task<IDataResult<SummaryDto>> Update(SummaryUpdateDto summaryUpdateDto,string modifiedByName);
        Task<IResult> Delete(int summaryId, string modifiedByName);
        Task<IResult> HardDelete(int summaryId);
    }
}
