using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.AboutMeDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    public class AboutMeController : Controller
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        public async Task<IActionResult> Index()
        {
            var aboutMe = await _aboutMeService.Get(1);

            if(aboutMe.ResultStatus == ResultStatus.Success)
            {
                return View(aboutMe.Data);
            }
            if (aboutMe.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 1)
        {
            if(id<0)
            {
                return NotFound();

            }
            
            var aboutMe = await _aboutMeService.GetUpdateDto(id);

            if(aboutMe.ResultStatus == ResultStatus.Success)
            {
                return View(aboutMe.Data);
            }
            if(aboutMe.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> Edit(AboutMeUpdateDto aboutMeUpdateDto,IFormFile fileImage,IFormFile fileCV)
        {
            if(ModelState.IsValid)
            {
                if(fileImage!=null)
                {

                }



            }
        }*/


        public async Task<IActionResult> Details(int id = 1)
        {
            if(id < 0)
            {
                return NotFound();
            }

            var aboutMe = await _aboutMeService.Get(id);

            if(aboutMe.ResultStatus == ResultStatus.Success)
            {
                return View(aboutMe.Data);
            }
            if(aboutMe.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return NotFound();
        }
    }
}
