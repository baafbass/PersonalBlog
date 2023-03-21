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
    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.educationTitle).IsRequired();
            builder.Property(x => x.educationTitle).HasMaxLength(50);
            builder.Property(x => x.School).IsRequired();
            builder.Property(x => x.School).HasMaxLength(100);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Duration).HasMaxLength(30);
            builder.Property(x => x.GradePointAverage).IsRequired();
            builder.Property(x => x.GradePointAverage).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.ToTable("Education");
            builder.HasData(new Education
            {
                ID = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                CreatedByName = "InitialCreated",
                ModifiedByName = "InitialCreated",
                IsActive = false,
                IsDeleted = false,
                educationTitle  = "License-Information System Engineering",
                School = "University Of Sakarya",
                Duration = "Oct.2021-Today",
                GradePointAverage = "3.19/4",
                Description = "We are learning programming and a litle of business"

            });
        }
    }
}
