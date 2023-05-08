using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;
        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IActionResult> Index()
        {
            var identity = await _siteService.Get(1);
            return View(identity.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 1)
        {
            var identity = await _siteService.GetUpdateDto(id);
            if (identity.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (identity.ResultStatus == ResultStatus.Success)
            {
                return View(identity.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SiteUpdateDto siteUpdateDto)
        {
          if(ModelState.IsValid)
            {
                await _siteService.Update(siteUpdateDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(siteUpdateDto);
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var identity = await _siteService.Get(id);
            if (identity.ResultStatus == ResultStatus.Success)
            {
                return View(identity.Data);
            }
            if (identity.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            return View();
        }
    }
}
