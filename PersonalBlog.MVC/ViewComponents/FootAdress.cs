using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class FooterAdress : ViewComponent
    {
        private readonly IContactInfoService _contactInfoService;

        public FooterAdress(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }
        public IViewComponentResult Invoke()
        {
            var data = GetContactInfo().Result;
            return View(data);
        }
        public async Task<ContactInfoDto> GetContactInfo()
        {
            var info = await _contactInfoService.Get(1);
            return info.Data;
        }
    }
}
