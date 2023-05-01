using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SiteDtos;
using PersonalBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.ViewComponents
{
    public class SiteIdentity : ViewComponent
    {
        private readonly ISiteService _siteIdentityService;

        public SiteIdentity(ISiteService siteIdentityService)
        {
            _siteIdentityService = siteIdentityService;
        }
        public IViewComponentResult Invoke(string title)
        {
            var data = GetSiteIdentity(title).Result;
            return View(data);
        }
        public async Task<SiteDto> GetSiteIdentity(string add)
        {
            var identity = await _siteIdentityService.Get(1);
            identity.Data.Site.siteName = identity.Data.Site.siteName + " | " + add;
            return identity.Data;
        }
    }
}
