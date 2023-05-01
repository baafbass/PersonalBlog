using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class NavbarHeader : ViewComponent
    {
        private readonly ISiteService _siteIdentityService;

        public NavbarHeader(ISiteService siteIdentityService)
        {
            _siteIdentityService = siteIdentityService;
        }
        public IViewComponentResult Invoke()
        {
            var idnt = GetIdentity().Result;
            return View(idnt);
        }
        public async Task<SiteDto> GetIdentity()
        {
            var identity = await _siteIdentityService.Get(1);
            return identity.Data;
        }
    }
}
