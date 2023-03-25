using PersonalBlog.Entities.Dtos.SummaryDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Concrete
{
    public class SummaryService : ISummaryService
    {
        public Task<IDataResult<SummaryDto>> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SummaryDto>> UpdateAsync(SummaryDto summaryDto)
        {
            throw new NotImplementedException();
        }
    }
}
