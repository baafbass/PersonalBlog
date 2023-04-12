using PersonalBlog.Entities.Dtos.CategoryDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetUpdateDto(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDelete();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto,string createdByName);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName);
        Task<IResult> Delete(int categoryId,string modifiedByName);
        Task<IResult> HardDelete(int categoryId);
    }
}
