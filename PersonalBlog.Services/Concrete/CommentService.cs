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

        public async Task<IDataResult<CommentDto>> Add(CommentAddDto commentAddDto, string modifiedByName)
        {
                var comment = _mapper.Map<Comments>(commentAddDto);
                comment.CreatedTime = DateTime.Now;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedByName = modifiedByName;
                var addedComment = await _unitOfWork.Comments.AddAsync(comment);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success,
                    new CommentDto
                    { 
                        Comments = addedComment,
                        ResultStatus = ResultStatus.Success,
                        Info = "Operation Successed"
                    });
        }

        public async Task<IResult> Delete(int CommentId,string modifiedByName)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == CommentId);
            if (comment != null)
            {
                comment.IsDeleted = true;
                comment.ModifiedTime = DateTime.Now;
                comment.ModifiedByName = modifiedByName;
                await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,"Operation Successed");
            }
            return new Result(ResultStatus.Error, "Failed to DELETE");
        }

        public async Task<IResult> DoActive(int commentId, string modifiedByName)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == commentId);
            
            if(comment!=null)
            {
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedTime = DateTime.Now;
                await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"The comment of {comment.FirstName} person was successfully Confirmed");
            }
            return new Result(ResultStatus.Error, "Operation Failed");
        }

        public async Task<IDataResult<CommentDto>> Get(int CommentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == CommentId,x=>x.Article);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, 
                    new CommentDto 
                    {
                        Comments = comment,
                        ResultStatus = ResultStatus.Success,
                    });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, 
                new CommentDto 
                {
                 Comments =null,
                 Info ="Error,No Record is found",
                 ResultStatus = ResultStatus.Error
                }, "Error,No record is found");
        }

        public async Task<IDataResult<CommentListDto>> GetAll()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(null,x=>x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success,
                    new CommentListDto
                    {
                        Comments = comments,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error,
                new CommentListDto
                { 
                 Comments =null,
                 ResultStatus = ResultStatus.Error,
                 Info = "Failed to List the elements"
                }, "Failed to List the elements");
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDelete()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(x => x.IsDeleted == false,x=>x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, 
                    new CommentListDto 
                    { 
                        Comments = comments,
                        ResultStatus =ResultStatus.Success
                     });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error,
                new CommentListDto
                { 
                 Comments = null,
                 Info = "Error,Failed to List the Elements",
                 ResultStatus = ResultStatus.Error
                
                }, "Failed to List the elements");
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeleteAndActive()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true,x=>x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success,
                    new CommentListDto 
                    {
                        Comments = comments,
                        ResultStatus = ResultStatus.Success
                    });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, 
                new CommentListDto 
                {
                 Comments = null,
                 ResultStatus = ResultStatus.Error,
                 Info = "Failed to List the elements"
                }, "Failed to List the elements");
        }

        public async Task<IDataResult<CommentUpdateDto>> GetUpdateDto(int CommentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == CommentId);

            if(comment!=null)
            {
                var updateCommentDto = _mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, updateCommentDto);
            }
            return new DataResult<CommentUpdateDto>(ResultStatus.Error,null,"Error,It was not found"),
        }

        public async Task<IResult> HardDelete(int commentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.ID == commentId);
            if (comment != null)
            {
                await _unitOfWork.Comments.DeleteAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,"Operation is successed");
            }
            return new Result(ResultStatus.Error, "Error, Failed to delete");
        }

        public async Task<IDataResult<CommentDto>> Update(CommentUpdateDto commentUpdateDto,string modififedByName)
        {
                var comment = _mapper.Map<Comments>(commentUpdateDto);
                comment.ModifiedByName = modififedByName;
                comment.ModifiedTime = DateTime.Now;
                var updatedComment = await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                { 
                    Comments = updatedComment,
                    ResultStatus = ResultStatus.Success
                });
        }
    }
}
