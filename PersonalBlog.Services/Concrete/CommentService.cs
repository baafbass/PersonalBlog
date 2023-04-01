using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.CommentsDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using PersonalBlog.Shared.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Concrete
{
    public class CommentService :ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CommentDto>> Add(CommentAddDto commentAddDto)
        {
            if (commentAddDto != null)
            {
                var comment = _mapper.Map<Comments>(commentAddDto);
                await _unitOfWork.Comments.AddAsync(comment);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto { Comments = comment });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == id);
            if (comment != null)
            {
                comment.IsDeleted = true;
                comment.ModifiedTime = DateTime.Now;
                await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Failed to DELETE");
        }

        public async Task<IDataResult<CommentDto>> Get(int id)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == id);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto { Comments = comment });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, null, "Error,No record is found");
        }

        public async Task<IDataResult<CommentListDto>> GetAll()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync();
            if (comments.Count > 0)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto { Comments = comments });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDelete()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(x => x.IsDeleted == false);
            if (comments.Count > 0)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto { Comments = comments });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeleteAndActive()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true);
            if (comments.Count > 0)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto { Comments = comments });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, null, "Failed to List the elements");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == id);
            if (comment != null)
            {
                await _unitOfWork.Comments.DeleteAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error, Failed to delete");
        }

        public async Task<IDataResult<CommentDto>> Update(CommentUpdateDto commentUpdateDto)
        {
            if (commentUpdateDto != null)
            {
                var comment = _mapper.Map<Comments>(commentUpdateDto);
                await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                { Comments = comment});
            }
            return new DataResult<CommentDto>(ResultStatus.Error, null, "Failed to Update");
        }
    }
}
