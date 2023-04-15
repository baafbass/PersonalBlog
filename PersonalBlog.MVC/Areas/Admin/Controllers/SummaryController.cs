using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entities.Dtos.SummaryDtos;
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
    public class SummaryController : Controller
    {
        private readonly ISummaryService _summaryService;
        public SummaryController(ISummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        public async Task<IActionResult> Index()
        {
            var summary = await _summaryService.Get(1);
            if (summary.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (summary.ResultStatus == ResultStatus.Success)
            {
                return View(summary.Data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var summary = await _summaryService.GetUpdateDto(id);
            if (summary.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if (summary.ResultStatus == ResultStatus.Success)
            {
                return View(summary.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SummaryUpdateDto summaryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _summaryService.Update(summaryUpdateDto, "Hasan Erdal");
                return RedirectToAction("Index");
            }
            return View(summaryUpdateDto);
        }
    }
}
