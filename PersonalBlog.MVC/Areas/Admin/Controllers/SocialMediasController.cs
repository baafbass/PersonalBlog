using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{     [Area("Admin")]
      [Authorize]
    public class SocialMediasController : Controller
    {
        private readonly ISocialMediasService _socialMediaService;

        public SocialMediasController(ISocialMediasService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }


        public async Task<IActionResult> Index()
        {
            var accounts = await _socialMediaService.GetAll();

            if (accounts.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(accounts.ResultStatus == ResultStatus.Success)
            {
                return View(accounts.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SocialMediasAddDto socialMediasAddDto)
        {
            if(ModelState.IsValid)
            {
                await _socialMediaService.Add(socialMediasAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(socialMediasAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id <1)
            {
                return NotFound();
            }
            var account = await _socialMediaService.GetUpdateDto(id);
            if(ResultStatus.Success == account.ResultStatus)
            {
                return View(account.Data);
            }
            if(account.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SocialMediasUpdateDto accountUpdateDto)
        {
            if(ModelState.IsValid)
            {
                await _socialMediaService.Update(accountUpdateDto,"Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(accountUpdateDto);
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var account = await _socialMediaService.Get(id);
            if(account.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(account.ResultStatus == ResultStatus.Success)
            {
                return View(account.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _socialMediaService.HardDelete(id);
            return RedirectToAction("Index");
        }


    }
}
