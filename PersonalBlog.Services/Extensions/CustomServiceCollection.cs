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
    public static class CustomServiceCollection
    {
        public static IServiceCollection MyCusTomService(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISummaryService, SummaryService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<IContactMeService, ContactMeService>();
            services.AddScoped<IHobbiesService, HobbiesService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ISocialMediasService, SocialMediasService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ISkillsService, SkillsService>();
            return services;
        }
    }
}
