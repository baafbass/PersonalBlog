using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class Experiences : ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public Experiences(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        public IViewComponentResult Invoke()
        {
            var datas = GetExperiences().Result;
            return View(datas);
        }
        public async Task<ExperiencesListDto> GetExperiences()
        {
            var experiences = await _experienceService.GetAllByNonDeleteAndActive();
            return experiences.Data;
        }
    }
}
