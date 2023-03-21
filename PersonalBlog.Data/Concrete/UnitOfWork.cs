using PersonalBlog.Data.Abstract;
using PersonalBlog.Data.Concrete.EntityFramework.Contexts;
using PersonalBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        private EfSummaryRepository _efSummaryRepository;
        private EfSocialMediasRepository _efSocialMediasRepository;
        private EfSkillsRepository _efSkillsRepository;
        private EfSiteRepository _efSiteRepository;
        private EfHomePageSlidersRepository _efHomePageSlidersRepository;
        private EfHobbiesRepository _efHobbiesRepository;
        private EfExperiencesRepository _efExperiencesRepository;
        private EfEducationRepository _efEducationRepository;
        private EfContactInfoRepository _efContactInfoRepository;
        private EfContactMeRepository _efContactMeRepository;
        private EfCommentsRepository _efCommentsRepository;
        private EfCategoriesRepository _efCategoriesRepository;
        private EfArticlesRepository _efArticlesRepository;
        private EfAdminRepository _efAdminRepository;
        private EfAboutMeRepository _efAboutMeRepository;
        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }
        //UnitOfWork.Summary.Add(Entity)
        //UnitOFWork.SaveChnagesAsunc()
        public IAboutMeRepository AboutMe => _efAboutMeRepository ?? new EfAboutMeRepository(_context);

        public IAdminRepository Admin => _efAdminRepository ?? new EfAdminRepository(_context);

        public IArticlesRepository Article => _efArticlesRepository ?? new EfArticlesRepository(_context);

        public ICategoriesRepository Categories => _efCategoriesRepository ?? new EfCategoriesRepository(_context);

        public ICommentsRepository Comments => _efCommentsRepository ?? new EfCommentsRepository(_context);

        public IContactInfoRepository ContactInfo => _efContactInfoRepository ?? new EfContactInfoRepository(_context);

        public IContactMeRepository ContactMe => _efContactMeRepository ?? new EfContactMeRepository(_context);

        public IEducationRepository Education => _efEducationRepository ?? new EfEducationRepository(_context);

        public IExperiencesRepository Experiences => _efExperiencesRepository ?? new EfExperiencesRepository(_context);

        public IHobbiesRepository Hobbies => _efHobbiesRepository ?? new EfHobbiesRepository(_context);

        public IHomePageSlidersRepository HomePageSliders => _efHomePageSlidersRepository ?? new EfHomePageSlidersRepository(_context);

        public ISiteRepository Site => _efSiteRepository ?? new EfSiteRepository(_context);

        public ISkillsRepository Skills => _efSkillsRepository ?? new EfSkillsRepository(_context);

        public ISocialMediasRepository SocialMedias => _efSocialMediasRepository ?? new EfSocialMediasRepository(_context);

        public ISummaryRepository Summary => _efSummaryRepository ?? new EfSummaryRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
