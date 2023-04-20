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
    public class AdminMap : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(250);
            builder.Property(x => x.SecurityQuestions).IsRequired();
            builder.Property(x => x.SecurityQuestions).HasMaxLength(200);
            builder.Property(x => x.SQAnswers).IsRequired();
            builder.Property(x => x.SQAnswers).HasMaxLength(250);
            builder.ToTable("Admin");
            builder.HasData(new Admin
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                Email = "abdoulfaridbassirou7898@gmai.com",
                PasswordHash = "3a799ade3169bd0d5da32652a3a888c5",
                SecurityQuestions = "What is your father name",
                SQAnswers = "a453e0ac9f56a805e5249ffdf7d04847"
            });
        }
    }
}
