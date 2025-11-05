using BookShop_MVC.Models.Enums;

namespace BookShop_MVC.Models.Entities
{
    public class User
    {
        public int  Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
