using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalBlog.Services.AutoMapper;
using PersonalBlog.Services.Extensions;


namespace PersonalBlog.MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(AboutMeProfile), typeof(AdminProfile), typeof(ArticleProfile), typeof(CategoryProfile), typeof(CommentProfile), typeof(ContactInfoProfile), typeof(EducationProfile), typeof(ExperienceProfile), typeof(SliderProfile), typeof(HobbyProfile), typeof(ContactMeProfile), typeof(SiteProfile), typeof(SkillProfile), typeof(SocialMediasProfile), typeof(SummaryProfile));
            services.LoadMyService();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {option.LoginPath = "/Admin/Session/LogIn"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapAreaControllerRoute(
                  name: "Admin",
                  areaName: "Admin",
                  pattern: "Admin/{controller = Home}/{action=Index}/{id?}"
                );

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
