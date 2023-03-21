using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Concrete.EntityFramework.Mappings
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.siteName).IsRequired();
            builder.Property(x => x.siteName).HasMaxLength(30);
            builder.Property(x => x.siteKeywords).IsRequired();
            builder.Property(x => x.siteKeywords).HasMaxLength(150);
            builder.Property(x => x.Logo).IsRequired();
            builder.Property(x => x.Logo).HasMaxLength(150);
            builder.Property(x => x.LogoTitle).IsRequired();
            builder.Property(x => x.LogoTitle).HasMaxLength(20);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.ToTable("Site");
            builder.HasData(new Site
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                siteName = "BAAF",
                siteKeywords = "C#,.NET,WEB,SOFTWARE",
                Logo = "<i class=\"fa - solid fa - display - code\"></i>",
                LogoTitle = "Farid Bass",
                Description = "Abdoul Faride Bassirou Alzouma Software Developer"
            });
        }   }
}
