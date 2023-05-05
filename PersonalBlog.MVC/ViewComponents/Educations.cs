using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.EducationDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    
        public class Educations : ViewComponent
        {
            private readonly IEducationService _educationService;

            public Educations(IEducationService educationService)
            {
                _educationService = educationService;
            }
         public IViewComponentResult Invoke()
         {
             var datas = GetEducations().Result;
             return View(datas);
         }
        public async Task<EducationListDto> GetEducations()
        {
            var educations = await _educationService.GetAllByNonDeleteAndActive();
            return educations.Data;
        }
    }
    }
