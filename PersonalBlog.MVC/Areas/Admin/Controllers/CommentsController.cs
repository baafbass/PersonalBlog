using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAll();

            if(comments.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }
            if(comments.ResultStatus == ResultStatus.Success)
            {
                return View(comments.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> CheckIt(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var comment = await _commentService.GetUpdateDto(id);

            if(comment.ResultStatus ==ResultStatus.Error)
            {
                return NotFound();
            }

            if(comment.ResultStatus == ResultStatus.Success)
            {
                if(comment.Data.IsActive==false)
                {
                    await _commentService.DoActive(id,"Abdoul Faride Bassirou Alzouma");
                }
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            var comment = await _commentService.Get(id);

            if(comment.ResultStatus == ResultStatus.Error)
            {
                return NotFound();
            }

            if(comment.ResultStatus == ResultStatus.Success)
            {
                return View(comment.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> DoHardDelete(int id)
        {
            if(id<1)
            {
                return NotFound();
            }

            await _commentService.HardDelete(id);
            return RedirectToAction("Index");
        }

    }
}
