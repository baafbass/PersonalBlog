using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.CategoryDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();

            if(categories.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(categories.ResultStatus == ResultStatus.Success)
            {
                return View(categories.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.Add(categoryAddDto,"Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(categoryAddDto);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var category = await _categoryService.GetUpdateDto(id);

            if (category.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(category.ResultStatus == ResultStatus.Success)
            {
                return View(category.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateDto categoryUpdateDto)
        {
            if(ModelState.IsValid)
            {
               await _categoryService.Update(categoryUpdateDto,"Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(categoryUpdateDto);
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var category = await _categoryService.Get(id);

            if(category.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(category.ResultStatus == ResultStatus.Success)
            {
                return View(category.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _categoryService.HardDelete(id);
            return RedirectToAction("Index");
        }

    }
}
