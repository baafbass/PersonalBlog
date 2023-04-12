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
        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto,string modifiedByName)
        {
            
                var category = _mapper.Map<Categories>(categoryAddDto);
                category.ModifiedByName = modifiedByName;
                category.ModifiedByName = modifiedByName;
                category.CreatedTime = DateTime.Now;
                var addedCategory = await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, 
                    new CategoryDto 
                    {
                        Category = addedCategory,
                        ResultStatus = ResultStatus.Success,
                        Info = $"The Catgory of {category.Name} Name was successfully registered"
                    }, $"The Catgory of {category.Name} Name was successfully registered");
        }

        public async Task<IResult> Delete(int categoryId,string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == categoryId);
            if(category!=null)
            {
                category.IsDeleted = true;
                category.ModifiedTime = DateTime.Now;
                category.ModifiedByName = modifiedByName;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Category with {category.Name} name was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "Failed to DELETE");
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == categoryId);
            if(category!=null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
            { 
             ResultStatus = ResultStatus.Error,
             Info = "Error,No record is found",
             Category = category
            }, "Error,No record is found");
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if(categories.Count>-1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success,
                    new CategoryListDto
                    {
                        Categories = categories,
                        ResultStatus = ResultStatus.Success
                    }) ;
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error,new CategoryListDto
            { 
             ResultStatus =ResultStatus.Error,
             Categories = null,
             Info ="Failed to List the elements"
            }, "Failed to List the elements");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDelete()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x=>x.IsDeleted==false);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success,
                    new CategoryListDto
                    {
                        Categories = categories,
                        ResultStatus = ResultStatus.Success
                    }) ;
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, new CategoryListDto 
            {
             Categories = null,
             ResultStatus = ResultStatus.Error,
             Info = "Failed to List The Elements",
            }, "Failed to List the elements");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x=>x.IsDeleted==false && x.IsActive==true);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success,
                    new CategoryListDto 
                    {
                        Categories = categories,
                        ResultStatus =ResultStatus.Success
                    });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, 
                new CategoryListDto
                {
                    Categories = null,
                    Info = "Failled to List the elements",
                    ResultStatus = ResultStatus.Info
                }, "Failed to List the elements");
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetUpdateDto(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == categoryId);
            if(category!=null)
            {
                var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            return new DataResult<CategoryUpdateDto>(ResultStatus.Error, null,"The Category was not found");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.ID == categoryId);
            if(category!=null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Category with the name {category.Name} was successfully Deleted");
            }
            return new Result(ResultStatus.Error, "Error, Failed to delete");
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName)
        { 
                var category = _mapper.Map<Categories>(categoryUpdateDto);
                category.ModifiedByName = modifiedByName;
                category.ModifiedTime = DateTime.Now;
               var updatedCategory = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = updatedCategory,
                    ResultStatus = ResultStatus.Success,
                }); 
        }
    }
}
