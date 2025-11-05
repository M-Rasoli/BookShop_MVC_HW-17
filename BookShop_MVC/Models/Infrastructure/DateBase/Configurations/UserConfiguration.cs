using BookShop_MVC.Models.Entities;
using BookShop_MVC.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop_MVC.Models.Infrastructure.DateBase.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Password).HasMaxLength(250).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(250).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(250);
            builder.Property(u => u.LastName).HasMaxLength(250);
            builder.Property(u => u.Role).HasConversion<string>();

            builder.HasData(new List<User>()
            {
                new User()
                {
                    Id = 1, UserName = "mmd", Password = "123", FirstName = "محمد", LastName = "رسولی",
                    Role = RoleEnum.Admin, CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
                new User()
                {
                    Id = 2, UserName = "ali", Password = "123", FirstName = "علی", LastName = "رسولی",
                    Role = RoleEnum.NormalUser, CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
                new User()
                {
                    Id = 3, UserName = "mahdi", Password = "123", FirstName = "مهدی", LastName = "رسولی",
                    Role = RoleEnum.NormalUser, CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
            });


        }
    }
}
