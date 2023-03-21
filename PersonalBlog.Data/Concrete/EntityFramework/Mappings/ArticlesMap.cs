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
    public class ArticlesMap : IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Overview).IsRequired();
            builder.Property(x => x.Overview).HasMaxLength(500);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Thumbnail).IsRequired();
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.Property(x => x.SeoTags).IsRequired();
            builder.Property(x => x.SeoTags).HasMaxLength(150);
            builder.Property(x => x.SeoDescription).IsRequired();
            builder.Property(x => x.SeoDescription).HasMaxLength(150);
            builder.Property(x => x.Views).IsRequired();
           builder.HasOne<Categories>(x => x.Categories).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
           builder.ToTable("Articles");
            
            
        }       
    }
}
