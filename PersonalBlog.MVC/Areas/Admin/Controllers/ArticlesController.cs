using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ArticlesDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public ArticlesController(IArticleService articleService,ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAll();

            if(articles.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(articles.ResultStatus == ResultStatus.Success)
            {
                return View(articles.Data);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> add()
        {
            var categories = await _categoryService.GetAllByNonDeleteAndActive();
            ViewBag.CategoryList = categories.Data.Categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticlesAddDto articlesAddDto,IFormFile fileImg)
        {
            if(ModelState.IsValid)
            {
                if(fileImg!=null)
                {
                    string imgExtension = Path.GetExtension(fileImg.FileName);
                    string imgName = Guid.NewGuid() + imgExtension;
                    string imgPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/uploads/img/{imgName}");
                    using var streamImg = new FileStream(imgPath, FileMode.Create);

                    await fileImg.CopyToAsync(streamImg);
                    articlesAddDto.Thumbnail = $"/uploads/img/{imgName}";
                }
                var article = await _articleService.Add(articlesAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllByNonDeleteAndActive();
            ViewBag.CategoryList = categories.Data.Categories;
            return View(articlesAddDto);
        }

    }
}
