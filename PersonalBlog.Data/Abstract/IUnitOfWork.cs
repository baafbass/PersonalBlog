using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IAboutMeRepository AboutMe { get;}
        IAdminRepository Admin { get; }
        IArticlesRepository Article { get; }
        ICategoriesRepository Categories { get; }
        ICommentsRepository Comments { get; }
        IContactInfoRepository ContactInfo { get; }
        IContactMeRepository ContactMe { get; }
        IEducationRepository Education { get; }
        IExperiencesRepository Experiences { get; }
        IHobbiesRepository Hobbies { get; }
        IHomePageSlidersRepository HomePageSliders { get; }
        ISiteRepository Site { get; }
        ISkillsRepository Skills { get; }
        ISocialMediasRepository SocialMedias { get; }
        ISummaryRepository Summary { get; }
        Task<int> SaveAsync();
    }
}
