using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.EducationDtos;
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
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IActionResult> Index()
        {
            var educations = await _educationService.GetAll();

            if(educations.ResultStatus==ResultStatus.Error)
            {
                return NotFound();
            }

            if(educations.ResultStatus==ResultStatus.Success)
            {
                return View(educations.Data);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EducationAddDto educationAddDto)
        {
            if(ModelState.IsValid)
            {
                await _educationService.Add(educationAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var education = await _educationService.Get(id);

            if(education.ResultStatus ==ResultStatus.Error)
            {
                return NotFound();
            }

            if(education.ResultStatus == ResultStatus.Success)
            {
                return View(education.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EducationUpdateDto educationUpdateDto)
        {
            if(ModelState.IsValid)
            {
                await _educationService.Update(educationUpdateDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var education = await _educationService.Get(id);

            if(education.ResultStatus ==ResultStatus.Error)
            {
                return NotFound();
            }

            if(education.ResultStatus == ResultStatus.Success)
            {
                return View(education.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var education = await _educationService.Get(id);

            if(education.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(education.ResultStatus == ResultStatus.Success)
            {
                return View(education.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _educationService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}
