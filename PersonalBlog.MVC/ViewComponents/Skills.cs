using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class Skills : ViewComponent
    {
        private readonly ISkillsService _skillService;

        public Skills(ISkillsService skillService)
        {
            _skillService = skillService;
        }
        public IViewComponentResult Invoke()
        {
            var datas = GetSkills().Result;
            return View(datas);
        }
        public async Task<SkillsListDto> GetSkills()
        {
            var skills = await _skillService.GetAllByNonDeleteAndActive();
            return skills.Data;
        }
    }
}
