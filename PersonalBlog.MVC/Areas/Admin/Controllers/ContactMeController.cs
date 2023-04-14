using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Concrete;
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
    public class ContactMeController : Controller
    {
        private readonly IContactMeService _contactMeService;
        public ContactMeController(IContactMeService contactMeService)
        {
            _contactMeService = contactMeService;
        }
        public async Task<IActionResult> Index()
        {
            var contactMe = await _contactMeService.GetAll();
            if(contactMe.ResultStatus== ResultStatus.Error)
            {
                return NotFound();
            }
            if(contactMe.ResultStatus == ResultStatus.Success)
            {
                return View(contactMe.Data);
            }

            return View();
        }

        public async Task<IActionResult> Checked(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _contactMeService.CheckMessage(id,"Abdoul Faride Bassirou Alzouma");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            { 
                return NotFound();
            }

            var contactMe = await _contactMeService.Get(id);

            if(contactMe.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(contactMe.ResultStatus == ResultStatus.Success)
            {
                return View(contactMe.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }
            await _contactMeService.HardDelete(id);
            return RedirectToAction("Index");
        }
    }
}
