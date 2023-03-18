﻿using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfSocialMediasRepository:EfEntityRepositoryBase<SocialMedias>,ISocialMediasRepository
    {
        public EfSocialMediasRepository(DbContext context):base(context)
        {

        }
    }
}