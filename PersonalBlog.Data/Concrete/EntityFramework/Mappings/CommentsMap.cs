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
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(512);
            builder.HasOne<Articles>(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
            builder.ToTable("Comments");
        }
    }
}
