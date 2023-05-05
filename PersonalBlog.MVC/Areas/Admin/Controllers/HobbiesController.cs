using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
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
    public class HobbiesController : Controller
    {
        private readonly IHobbiesService _hobbyService;

        public HobbiesController(IHobbiesService hobbyService)
        {
            _hobbyService = hobbyService;
        }

        public async  Task<IActionResult> Index()
        {
            var hobbies = await _hobbyService.GetAll();
            if(hobbies.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(hobbies.ResultStatus == ResultStatus.Success)
            {
                return View(hobbies.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(HobbiesAddDtos hobbiesAddDto)
        {
            if(ModelState.IsValid)
            {
                await _hobbyService.Add(hobbiesAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(hobbiesAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var hobby = await _hobbyService.GetUpdateDto(id);

            if(hobby.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(hobby.ResultStatus== ResultStatus.Success)
            {
                return View(hobby.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HobbiesUpdateDtos hobbiesUpdateDtos)
        {
          if(ModelState.IsValid)
            {
                var hobby = await _hobbyService.Update(hobbiesUpdateDtos, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(hobbiesUpdateDtos);
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var hobby = await _hobbyService.Get(id);
            if (hobby.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (hobby.ResultStatus == ResultStatus.Success)
            {
                return View(hobby.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _hobbyService.HardDelete(id);
            return RedirectToAction("Index");
        }



    }
}
