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
    public class AboutMeMap : IEntityTypeConfiguration<AboutMe>
    {
        public void Configure(EntityTypeBuilder<AboutMe> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20);
            builder.Property(x => x.profilPicture).IsRequired();
            builder.Property(x => x.profilPicture).HasMaxLength(250);
            builder.Property(x => x.Job).IsRequired();
            builder.Property(x => x.Job).HasMaxLength(50);
            builder.Property(x => x.JobIcon).IsRequired();
            builder.Property(x => x.JobIcon).HasMaxLength(150);
            builder.Property(x => x.CV).IsRequired();
            builder.Property(x => x.CV).HasMaxLength(250);
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Birthday).HasMaxLength(20);
            builder.ToTable("AboutMe");
            builder.HasData(new AboutMe
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                FirstName = "Abdoul Faride",
                LastName = "Bassirou Alzouma",
                profilPicture = "",
                Job = "Software Developer",
                JobIcon = "<i class=\"fa - solid fa - laptop - code\"></i>",
                CV ="",
                Birthday = "31.08.2001"

            });
        }
    }
}
