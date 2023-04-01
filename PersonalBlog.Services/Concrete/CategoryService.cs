using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.CategoryDtos;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto)
        {
            if(categoryAddDto !=null)
            {
                var category = _mapper.Map<Categories>(categoryAddDto);
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto { Category = category });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == id);
            if(category!=null)
            {
                category.IsDeleted = true;
                category.ModifiedTime = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Failed to DELETE");
        }

        public async Task<IDataResult<CategoryDto>> Get(int id)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == id);
            if(category!=null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto { Category = category });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, null, "Error,No record is found");
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if(categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDelete()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x=>x.IsDeleted==false);
            if (categories.Count > 0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x=>x.IsDeleted==false && x.IsActive==true);
            if (categories.Count > 0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == id);
            if(category!=null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, Failed to delete");
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto)
        {
         if(categoryUpdateDto!=null)
            {
                var category = _mapper.Map<Categories>(categoryUpdateDto);
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category
                }); 
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, null, "Failed to Update");
        }
    }
}
