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

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ArticleDto>> Add(ArticlesAddDto articlesAddDto, string createdByName)
        {
            var article = _mapper.Map<Articles>(articlesAddDto);
            article.CreatedTime = DateTime.Now;
            article.CreatedByName = createdByName;
            var addedArticle = await _unitOfWork.Article.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
            {
                Articles = addedArticle,
                ResultStatus = ResultStatus.Success,
                Info = $"The Article with title {articlesAddDto.Title} is successfully added!"
            }, $"The Article with title {articlesAddDto.Title} is successfully added!");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == articleId);
            if (article != null)
            {
                article.IsDeleted = true;
                article.ModifiedTime = DateTime.Now;
                article.ModifiedByName = modifiedByName;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"The Article with Title {article.Title} is successfully Deleted !");
            }
            return new Result(ResultStatus.Error, "Error,Failed to Delete");
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == articleId,x=>x.Categories,x=>x.Comments);
            if(article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, new ArticleDto
            { 
             ResultStatus = ResultStatus.Error,
             Info = "No recocrd is found",
             Articles = null
            }, "Error,No record is found");
        }

        public async Task<IDataResult<ArticlesListDto>> Get3MostReadByNonDeleteAndActive()
        {
            var articles = await _unitOfWork.Article.Get3MostReadAsync(x => x.IsDeleted == false && x.IsActive == true, x => x.Categories, x => x.Comments);
            if(articles.Count>-1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Info = "Error,No Element is fouund"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAll()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(null,x=>x.Categories,x=>x.Comments);
            if(articles.Count >-1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto 
            {
             Articles = null,
             Info = "Error, Failed to the elements",
             ResultStatus = ResultStatus.Error
            }, "Error,Failed to list the articles");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDelete()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x=>x.IsDeleted ==false,x=>x.Categories,x=>x.Comments); 
            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto 
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto
            {
                Articles = null,
                Info = "Error, Failed to list the articles",
                ResultStatus = ResultStatus.Error
            }, "Error,Failed to list the articles");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true, x => x.Categories, x => x.Comments);
            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto
            { 
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Info = "Error,Failed to list the Articles"
            }, "Error,Failed to list the articles");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == articleId);

           if(article!=null)
            {
                await _unitOfWork.Article.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"The Article with {article.Title} tile was successfully Deleted From The Database");
            }
            return new Result(ResultStatus.Error, "Error,Failed to DELETE");
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveOrderedByDescendingId()
        {
            var articles = await _unitOfWork.Article.GetAllOrderByDescIdAsync(x=>x.IsDeleted==false && x.IsActive==true,x=>x.Categories,x=>x.Comments);
            
            if(articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto
            { 
             Articles = null,
             Info = "Error,Operation Failed",
             ResultStatus = ResultStatus.Error,
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveWithCategoryId(int categoryId)
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDeleted == false && x.CategoryId==categoryId && x.IsActive == true, x => x.Categories, x => x.Comments
            );

            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            
            return new DataResult<ArticlesListDto>(ResultStatus.Error, new ArticlesListDto
            {
                ResultStatus = ResultStatus.Error,
                Info = "Error,Failed To Get It",
                Articles = null
            },"Error,Failed To Get It");
        }

        public async Task<IDataResult<ArticlesUpdateDto>> GetUpdateDto(int articleId)
        {
            var articles = await _unitOfWork.Article.GetAsync(x => x.ID == articleId,x=>x.Categories,x=>x.Comments);
            if(articles!=null)
            {
                var updateArticleDto = _mapper.Map<ArticlesUpdateDto>(articles);
                return new DataResult<ArticlesUpdateDto>(ResultStatus.Success, updateArticleDto);
            }
            return new DataResult<ArticlesUpdateDto>(ResultStatus.Error, null,"Error,The Element was not found");
        }

        public async Task<IDataResult<ArticleDto>> Update(ArticlesUpdateDto articlesUpdateDto,string modifiedByName)
        {
                var article = _mapper.Map<Articles>(articlesUpdateDto);
                article.ModifiedByName = modifiedByName;
                article.ModifiedTime = DateTime.Now;
                var updatedArticle = await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new DataResult<ArticleDto>(ResultStatus.Success,
                    new ArticleDto 
                    {
                        Articles = updatedArticle,
                        ResultStatus = ResultStatus.Success
                    });
        }

        public async Task<IResult> AddViews(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.ID == articleId);
            if(article!=null)
            {
                article.Views = article.Views + 1;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Error,Operation is Failed");
        }
    }
}
