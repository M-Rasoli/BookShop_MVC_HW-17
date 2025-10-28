using BookShop_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop_MVC.Models.Infrastructure.DateBase.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(800);

            builder.HasMany(c => c.Books).WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasData(new List<Category>()
            {
                new Category(){Id = 1, Title = "رمان و داستان", Description = "معاصر ، کلاسیک " , CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Category(){Id = 2, Title = "فلسفه و منطق", Description = "غرب و شرق" , CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Category(){Id = 3, Title = "علمی و تاریخی", Description = "فناوری و تاریخ" , CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Category(){Id = 4, Title = "کودک و نونجوان", Description = "داستان های مصور" , CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Category(){Id = 5, Title = "هنر و معماری", Description = "طراحی و نقاشی" , CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
            });
        }
    }
}
