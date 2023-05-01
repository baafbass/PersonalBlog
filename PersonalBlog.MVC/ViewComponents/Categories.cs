using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.CategoryDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public Categories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var datas = GetCategories().Result;
            return View(datas);
        }

        public async Task<CategoryListDto> GetCategories()
        {
            var categories = await _categoryService.GetAllByNonDeleteAndActive();
            return categories.Data;
        }
    }
}
