using BookShop_MVC.Models.Enums;

namespace BookShop_MVC.Application.DTOs
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEnum Role { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
    }
}
