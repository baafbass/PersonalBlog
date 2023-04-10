using PersonalBlog.Entities.Dtos.ArticlesDtos;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticlesUpdateDto>> GetUpdateDto(int articleId);
        Task<IResult> AddViews(int articleId);
        Task<IDataResult<ArticlesListDto>> GetAll();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDelete();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveWithCategoryId(int categoryId);
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveOrderedByDescendingId();
        Task<IDataResult<ArticlesListDto>> Get3MostReadByNonDeleteAndActive();
        Task<IDataResult<ArticleDto>> Add(ArticlesAddDto articlesAddDto,string createdByName);
        Task<IDataResult<ArticleDto>> Update(ArticlesUpdateDto articlesUpdateDto,string modifiedByName);
        Task<IResult> Delete(int articleId,string modifiedByName);
        Task<IResult> HardDelete(int articleId);

    }
}
