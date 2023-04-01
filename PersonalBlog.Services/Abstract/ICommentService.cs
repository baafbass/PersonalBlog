using PersonalBlog.Entities.Dtos.CategoryDtos;
using PersonalBlog.Entities.Dtos.CommentsDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<CommentDto>> Get(int id);
        Task<IDataResult<CommentListDto>> GetAll();
        Task<IDataResult<CommentListDto>> GetAllByNonDelete();
        Task<IDataResult<CommentListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<CommentDto>> Add(CommentAddDto commentAddDto);
        Task<IDataResult<CommentDto>> Update(CommentUpdateDto commentUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);
    }
}
