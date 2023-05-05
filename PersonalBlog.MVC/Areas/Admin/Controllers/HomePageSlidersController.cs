using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SlidersDtos;
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
    public class HomePageSlidersController : Controller
    {
        private readonly ISlidersService _sliderService;

        public HomePageSlidersController(ISlidersService sliderService)
        {
            _sliderService = sliderService;
        }
        
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAll();
            if (sliders.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(sliders.ResultStatus == ResultStatus.Success)
            {
                return View(sliders.Data);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var slider = await _sliderService.Get(id);
            if(slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
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

            var slider = await _sliderService.GetUpdateDto(id);
            if(slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SlidersUpdateDto sliderUpdateDto)
        {
            if(ModelState.IsValid)
            {
                await _sliderService.Update(sliderUpdateDto,"Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SlidersAddDto sliderAddDto)
        {
            if(ModelState.IsValid)
            {
                await _sliderService.Add(sliderAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var slider = await _sliderService.Get(id);

            if(slider.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(slider.ResultStatus == ResultStatus.Success)
            {
                return View(slider.Data);
            }
            return View();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<0)
            {
                return NotFound();
            }
            await _sliderService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}
