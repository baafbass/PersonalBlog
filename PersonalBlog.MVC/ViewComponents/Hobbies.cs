using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.HobbiesDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class Hobbies : ViewComponent
    {
        private readonly IHobbiesService _hobbyService;

        public Hobbies(IHobbiesService hobbyService)
        {
            _hobbyService = hobbyService;
        }
        public IViewComponentResult Invoke()
        {
            var datas = GetInteresteds().Result;
            return View(datas);
        }
        public async Task<HobbiesListDtos> GetInteresteds()
        {
            var interesteds = await _hobbyService.GetAllByNonDeleteAndActive();
            return interesteds.Data;
        }
    }
}
