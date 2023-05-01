using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SocialMediasDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class FooterAccounts : ViewComponent
    {
        private readonly ISocialMediasService _socialMediaAccountService;

        public FooterAccounts(ISocialMediasService socialMediaAccountService)
        {
            _socialMediaAccountService = socialMediaAccountService;
        }
        public IViewComponentResult Invoke()
        {
            var list = GetAccounts().Result;
            return View(list);
        }
        public async Task<SocialMediasListDto> GetAccounts()
        {
            var accounts = await _socialMediaAccountService.GetAllByNonDeleteAndActive();
            return accounts.Data;
        }
    }
}
