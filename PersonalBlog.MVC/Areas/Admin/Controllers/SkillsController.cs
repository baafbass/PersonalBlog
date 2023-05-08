using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SkillsDtos;
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
    //[Route("Admin/Skill")]
    public class SkillsController : Controller
    {
        private readonly ISkillsService _skillService;

        public SkillsController(ISkillsService skillService)
        {
            _skillService = skillService;
        }
        
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAll();
            if(skills.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(skills.ResultStatus == ResultStatus.Success)
            {
                return View(skills.Data);
            }
            return View();
        }

        public async Task<IActionResult> Details (int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            var skill = await _skillService.Get(id);
            if(skill.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
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
            var skill = await _skillService.GetUpdateDto(id);

            if(skill.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillsUpdateDto skillsUpdateDto)
        {
            if(ModelState.IsValid)
            {
                await _skillService.Update(skillsUpdateDto,"Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View(skillsUpdateDto);
        }
        
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var skill = await _skillService.Get(id);

            if(skill.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(skill.ResultStatus == ResultStatus.Success)
            {
                return View(skill.Data);
            }
            return View();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _skillService.HardDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SkillsAddDto skillAddDto)
        {
            if(ModelState.IsValid)
            {
                await _skillService.Add(skillAddDto, "Abdoul Faride Bassirou Alzouma");
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
