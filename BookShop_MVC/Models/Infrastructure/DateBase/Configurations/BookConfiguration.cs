using BookShop_MVC.Models.Entities;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop_MVC.Models.Infrastructure.DateBase.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(200).IsRequired();
            builder.Property(b => b.NumberOfPages).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Price).HasMaxLength(100).IsRequired();

            builder.HasData(new List<Book>()
            {
                 new Book()
                {
                    Id = 1,
                    Title = "نبرد من",
                    Author = "آدولف هیتلر",
                    NumberOfPages = 430,
                    Price = 750000,
                    CategoryId = 1,
                    ImgUrl = "/img/nabardman.jpg",
                    CreatedAt = new DateTime(2024,12,12,12,12,12,12,DateTimeKind.Local),
                },
                // 📚 رمان و داستان
                // 💭 فلسفه و منطق
                new Book()
                {
                    Id = 2,
                    Title = "جمهور",
                    Author = "افلاطون",
                    NumberOfPages = 410,
                    Price = 600000,
                    CategoryId = 2,
                    ImgUrl = "/img/jomhor.jpg",
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local),
                },

                // 🔬 علمی و تاریخی
                new Book()
                {
                    Id = 3,
                    Title = "خاستگاه گونه‌ها",
                    Author = "چارلز داروین",
                    NumberOfPages = 510,
                    Price = 750000,
                    CategoryId = 3,
                    ImgUrl = "/img/khastgah.jpg",
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local),
                },
            
                // 🧒 کودک و نوجوان
                new Book()
                {
                    Id = 4,
                    Title = "شازده کوچولو",
                    Author = "آنتوان دو سنت اگزوپری",
                    NumberOfPages = 120,
                    Price = 280000,
                    CategoryId = 4,
                    ImgUrl = "/img/shazde.jpg",
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local),
                },
                // 🎨 هنر و معماری
                new Book()
                {
                    Id = 5,
                    Title = "تاریخ هنر",
                    Author = "ارنست گامبریچ",
                    NumberOfPages = 680,
                    Price = 850000,
                    CategoryId = 5,
                    ImgUrl = "/img/tarikhhonar.jpg",
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local),
                },
            });
        }
    }
}
