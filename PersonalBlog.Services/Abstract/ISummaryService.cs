using PersonalBlog.Entities.Dtos.SummaryDtos;
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
        Task<IDataResult<SummaryDto>> GetAsync(int Id);
        Task<IDataResult<SummaryDto>> UpdateAsync(SummaryDto summaryDto);

    }
}
