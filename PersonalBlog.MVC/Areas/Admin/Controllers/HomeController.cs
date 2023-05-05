using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.AdminDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ISkillsService _skillService;
        private readonly ISlidersService _homeSliderService;
        private readonly IContactMeService _contactMeService;
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly IHobbiesService _hobbyService;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAdminService _adminService;

        public HomeController(ICategoryService categoryService,IAdminService adminService,IArticleService articleService,IHobbiesService hobbyService,IExperienceService experienceService,IEducationService educationService,ISkillsService skillService, ISlidersService homeSliderService, IContactMeService contactMeService)
        {
          _skillService = skillService;
          _homeSliderService = homeSliderService;
          _contactMeService = contactMeService;
          _educationService = educationService;
          _experienceService = experienceService;
          _hobbyService = hobbyService;
          _articleService = articleService;
          _categoryService = categoryService;
          _adminService = adminService;
         } 

        //[Route("Admin/Session/LogIn")]
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAll();
            var educations = await _educationService.GetAll();
            var experiences = await _experienceService.GetAll();
            var hobbies = await _hobbyService.GetAll();
            var categories = await _categoryService.GetAll();
            var articles = await _articleService.GetAll();
            var messages = await _contactMeService.GetAll();
            var sliders = await _homeSliderService.GetAll();

            ViewBag.SkillCount = skills.Data.Skills.Count;
            ViewBag.SliderCount = sliders.Data.Sliders.Count;
            ViewBag.ExperienceCount = experiences.Data.Experiences.Count;
            ViewBag.EducationCount = educations.Data.Education.Count;
            ViewBag.MessageCount = messages.Data.ContactMe.Count;
            ViewBag.HobbyCount = hobbies.Data.Hobbies.Count;
            ViewBag.ArticeCount = articles.Data.Articles.Count;
            ViewBag.CategoryCount = categories.Data.Categories.Count;

            return View();
        }

        public async Task<IActionResult> Setting()
        {
            var admin = await _adminService.Get(1);
            if(admin.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(admin.ResultStatus == ResultStatus.Success)
            {
                return View(admin.Data);
            }
            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> EditAdmin(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var admin = await _adminService.GetUpdateDto(id);

            if(admin.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(admin.ResultStatus == ResultStatus.Success)
            {
                return View(admin.Data);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> EditAdmin(AdminUpdateDto adminUpdateDto, string oldPsswrd, string oldSQHash)
        {
            if (ModelState.IsValid)
            {
                if (oldPsswrd != adminUpdateDto.PasswordHash)
                {
                    using var md5 = MD5.Create();
                    var result1 = md5.ComputeHash(Encoding.ASCII.GetBytes(adminUpdateDto.PasswordHash));
                    var strResult = BitConverter.ToString(result1);
                    adminUpdateDto.PasswordHash = strResult.Replace("-", "");
                }
                if (oldSQHash != adminUpdateDto.SecurityQuestions)
                {
                    using var md5New = MD5.Create();
                    var result2 = md5New.ComputeHash(Encoding.ASCII.GetBytes(adminUpdateDto.SecurityQuestions));
                    var strResult2 = BitConverter.ToString(result2);
                    adminUpdateDto.SecurityQuestions = strResult2.Replace("-", "");
                }
                await _adminService.Update(adminUpdateDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Setting");
            }
            return View(adminUpdateDto);
        }
    }
}
