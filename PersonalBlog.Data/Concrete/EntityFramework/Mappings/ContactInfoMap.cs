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
    public class ContactInfoMap : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Adress).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.phoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Adress).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.phoneNumber).HasMaxLength(20);
            builder.ToTable("ContactInfo");
            builder.HasData(new ContactInfo
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                phoneNumber = "+905315058891",
                Email = "abdoulfaridbassirou7898@gmail.com",
                City = "Sakarya/Serdiven",
                Adress = "Arif Nihat Asya Erkek Öğrenci Yurdu",



            });

        }
    }
}
