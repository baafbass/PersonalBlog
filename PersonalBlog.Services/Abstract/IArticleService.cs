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
        Task<IDataResult<ArticleDto>> Get(int id);
        Task<IResult> IncrementRead(int id);
        Task<IDataResult<ArticlesListDto>> GetAll();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDelete();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ArticleDto>> Add(ArticlesAddDto articlesAddDto);
        Task<IDataResult<ArticleDto>> Update(ArticlesUpdateDto articlesUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> HardDelete(int id);

    }
}
