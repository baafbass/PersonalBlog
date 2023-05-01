using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ArticlesDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class MostReadBlog : ViewComponent
    {
        private readonly IArticleService _articleService;

        public MostReadBlog(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var datas = GetArticles().Result;
            return View(datas);
        }
        public async Task<ArticlesListDto> GetArticles()
        {
            var articles = await _articleService.Get3MostReadByNonDeleteAndActive();
            return articles.Data;
        }
    }
}
