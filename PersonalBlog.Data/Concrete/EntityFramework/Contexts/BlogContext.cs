﻿using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Concrete.EntityFramework.Mappings;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Contexts
{
    public class BlogContext: DbContext
    {
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<ContactMe> ContactMe { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<HomePageSliders> HomePageSliders { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialMedias> SocialMedias { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-VOER1P3\SQLEXPRESS;Database=PersonalBlog;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new SummaryMap());
            modelBuilder.ApplyConfiguration(new SocialMediasMap());
            modelBuilder.ApplyConfiguration(new SkillsMap());
            modelBuilder.ApplyConfiguration(new SiteMap());
            modelBuilder.ApplyConfiguration(new HomePageSlidersMap());
            modelBuilder.ApplyConfiguration(new HobbiesMap());
            modelBuilder.ApplyConfiguration(new ExperiencesMap());
            modelBuilder.ApplyConfiguration(new EducationMap());
            modelBuilder.ApplyConfiguration(new ContactInfoMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new ContactMeMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new ArticlesMap());
            modelBuilder.ApplyConfiguration(new AdminMap());
            modelBuilder.ApplyConfiguration(new AboutMeMap());
        }
    }
}
