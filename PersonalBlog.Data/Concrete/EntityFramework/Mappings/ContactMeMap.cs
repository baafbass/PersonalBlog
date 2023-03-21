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
    public class ContactMeMap : IEntityTypeConfiguration<ContactMe>
    {
        public void Configure(EntityTypeBuilder<ContactMe> builder)
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
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(50);
            builder.Property(x => x.EmailAdress).IsRequired();
            builder.Property(x => x.EmailAdress).HasMaxLength(100);
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(512);
            builder.ToTable("ContactMe");
            builder.HasData(new ContactMe
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
                Subject = "Business",
                EmailAdress = "abdoulfaridbassirou7898@gmail.com",
                Message = "I will become a high value man and rich",
            });
        }
    }
}
