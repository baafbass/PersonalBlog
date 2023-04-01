using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ArticlesDtos;
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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ArticleDto>> Add(ArticlesAddDto articlesAddDto)
        {
            if(articlesAddDto!=null)
            {
                var article = _mapper.Map<Articles>(articlesAddDto);
                await _unitOfWork.Article.AddAsync(article);
                await _unitOfWork.SaveAsync();
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto { Articles = article });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, null, "Error,Failed to register");
        }

        public async Task<IResult> Delete(int id)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == id);
            if(article!=null)
            {
                article.IsDeleted = true;
                article.ModifiedTime = DateTime.Now;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,Failed to Delete");
        }

        public async Task<IDataResult<ArticleDto>> Get(int id)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == id,x=>x.Categories,x=>x.Comments);
            if(article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto { Articles = article });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, null, "Error,No record is found");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAll()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(null,x=>x.Categories);
            if(articles.Count >0)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto { Articles = articles });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, null, "Error,Failed to list the articles");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDelete()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x=>x.IsDeleted ==false,x=>x.Categories ); 
            if (articles.Count > 0)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto { Articles = articles });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, null, "Error,Failed to list the articles");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true,x=>x.Categories);
            if (articles.Count > 0)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto { Articles = articles });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, null, "Error,Failed to list the articles");
        }

        public async Task<IResult> HardDelete(int id)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == id);
           if(article!=null)
            {
                await _unitOfWork.Article.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,Failed to DELETE");
        }

        public async Task<IDataResult<ArticleDto>> Update(ArticlesUpdateDto articlesUpdateDto)
        {
            if(articlesUpdateDto!=null)
            {
                var article = _mapper.Map<Articles>(articlesUpdateDto);
                await _unitOfWork.Article.UpdateAsync(article);
                article.ModifiedTime = DateTime.Now;
                await _unitOfWork.SaveAsync();
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto { Articles = article });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, null, "Error,Failed to Update");
        }

        public async Task<IResult> IncrementRead (int id)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == id);
            if(article!=null)
            {
                article.Views += 1;
                article.ModifiedTime = DateTime.now;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,Operation is Failed");
        }
    }
}
