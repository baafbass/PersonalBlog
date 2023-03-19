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
    public class SocialMediasMap : IEntityTypeConfiguration<SocialMedias>
    {
        public void Configure(EntityTypeBuilder<SocialMedias> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.MediaName).IsRequired();
            builder.Property(x => x.MediaName).HasMaxLength(30);
            builder.Property(x => x.MediaLogo).IsRequired();
            builder.Property(x => x.MediaLogo).HasMaxLength(150);
            builder.Property(x => x.MediaURL).IsRequired();
            builder.Property(x => x.MediaURL).HasMaxLength(150);
            builder.ToTable("SocialMedias");
            builder.HasData(new SocialMedias
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                MediaName = "Facebook",
                MediaLogo = "<i class=\"fa - brands fa - facebook\"></i>",
                MediaURL = "https://www.facebook.com/baaf.baaf.7"

            }, new SocialMedias
            {
                ID = 2,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                MediaName = "LinkedIn",
                MediaURL = "https://www.linkedin.com/in/abdoul-faride-bassirou-alzouma-a61b321bb/",
                MediaLogo = "<i class=\"fa - brands fa - linkedin\"></i>"
            }, new SocialMedias
            {
                ID = 3,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                MediaName = "Instagram",
                MediaURL = "https://www.instagram.com/farid_bass_alz/",
                MediaLogo = "<i class=\"fa - brands fa - instagram\"></i>"
            });

        }
    }
}
