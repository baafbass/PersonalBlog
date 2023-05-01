using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete;
using PersonalBlog.Data.Concrete.EntityFramework.Contexts;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ISummaryService, SummaryManager>();
            serviceCollection.AddScoped<IAboutMeService, AboutMeManager>();
            serviceCollection.AddScoped<IAdminService, AdminManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<IEducationService, EducationManager>();
            serviceCollection.AddScoped<IExperienceService, ExperienceManager>();
            serviceCollection.AddScoped<IContactInfoService, ContactInfoManager>();
            serviceCollection.AddScoped<IContactMeService, ContactMeManager>();
            serviceCollection.AddScoped<IHobbiesService, HobbiesManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddScoped<IEducationService, EducationManager>();
            serviceCollection.AddScoped<ISocialMediasService, SocialMediasManager>();
            serviceCollection.AddScoped<ISiteService, SiteManager>();
            serviceCollection.AddScoped<ISkillsService, SkillsManager>();
            serviceCollection.AddScoped<ISlidersService, SlidersManager>();
            return serviceCollection;
        }
    }
}
