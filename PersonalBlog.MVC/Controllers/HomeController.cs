using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.CommentsDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalBlog.Shared.Helpers;
using PersonalBlog.Entities.Dtos.ContactMeDtos;

namespace PersonalBlog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlidersService _slidersService;
        private readonly IAboutMeService _aboutMeService;
        private readonly ISiteService _siteService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IArticleService _articleService;
        private readonly IContactMeService _contactMeService;
        private readonly ICommentService _commentService;

        public HomeController(ISlidersService slidersService,IAboutMeService aboutMeService,ISiteService siteService,IContactInfoService contactInfoService,ICommentService commentService,IArticleService articleService,IContactMeService contactMeService)
        {
            _slidersService = slidersService;
            _aboutMeService = aboutMeService;
            _siteService = siteService;
            _articleService = articleService;
            _commentService = commentService;
            _contactInfoService = contactInfoService;
            _contactMeService = contactMeService;
        }

        [Route("")]
        [Route("homepage")]
        public async Task<IActionResult> Index()
        {
            var sliders = await _slidersService.GetAllByNonDeleteAndActive();

            if(sliders.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(sliders.ResultStatus == ResultStatus.Success)
            {
                ViewBag.Home = "active";
                return View(sliders.Data);
            }
            return NotFound();
        }

        [Route("more/{Title}")]
        public async Task<IActionResult> SliderDetail(int id)
        {
            if(id<0)
            {
                return NotFound();
            }
            var slider = await _slidersService.Get(id);
            if(slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(slider.ResultStatus == ResultStatus.Success)
            {
                ViewBag.Home = "active";
                return View(slider.Data);
            }
            return NotFound();
        }

        [Route("aboutMe")]
        public async Task<IActionResult> About()
        {
            var aboutMe = await _aboutMeService.Get(1);
            if(aboutMe.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(aboutMe.ResultStatus == ResultStatus.Success)
            {
                var contactInfo = await _aboutMeService.Get(1);
                ViewBag.ContactInfo = contactInfo.Data.Info;
                ViewBag.about = "active";
                return View(contactInfo.Data);
            }
            return NotFound();
        }

        [Route("blog")]
        public async Task<IActionResult> Blog(int page=1)
        {
            ViewBag.Blog = "active";
            var articles = await _articleService.GetAllByNonDeleteAndActiveOrderedByDescendingId();
            var articleList = articles.Data.Articles;
            PagedList<Articles> List = new PagedList<Articles>(articleList.AsQueryable(), page, 3);
            return View(List);
        }

        [Route("blog/{category}")]
        public async Task<IActionResult> BlogWithCategory(int id,int page = 1)
        {
            ViewBag.Blog = "active";
            if(id<1)
            {
                return NotFound();
            }
            var articles = await _articleService.GetAllByNonDeleteAndActiveWithCategoryId(id);
            if(articles.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(articles.ResultStatus == ResultStatus.Success)
            {
                var articleList = articles.Data.Articles;
                PagedList<Articles> List = new PagedList<Articles>(articleList.AsQueryable(), page, 3);
                return View(List);
            }
            return NotFound();
        }
        
        [Route("blog/{name}/{id}")]
        public async Task<IActionResult> BlogDetail(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var article = await _articleService.Get(id);
            if(article.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(article.ResultStatus == ResultStatus.Success)
            {
                ViewBag.ArticleId = id;
                ViewBag.Blog = "active";
                await _articleService.AddViews(id);
                return View(article.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddDto commentsAddDto)
        {
            var result = await _articleService.Get(commentsAddDto.ArticleId);
            var article = result.Data.Articles;

            if(ModelState.IsValid)
            {
                var createdName = commentsAddDto.FirstName + commentsAddDto.LastName;
                await _commentService.Add(commentsAddDto, createdName);
                return RedirectToAction("BlogDetail", new { name = SeoHelper.ToSeoUrl(article.Title), id = article.ID });
            }
            return RedirectToAction("BlogDetail", new { name = SeoHelper.ToSeoUrl(article.Title), id = article.ID });
        }

        [Route("contact")]
        public async Task<IActionResult> Contact()
        {
            ViewBag.Contact = "active";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactMeAddDto messageAddDto)
        {
            if(ModelState.IsValid)
            {
                var createdName = messageAddDto.FirstName + messageAddDto.LastName;
                await _contactMeService.Add(messageAddDto, createdName);
                return RedirectToAction("Contact");
            }
            return View(messageAddDto);
        }

    }
}
