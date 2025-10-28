using BookShop_MVC.Application.DTOs;

namespace BookShop_MVC.Models
{
    public class CategoryBookViewModel
    {
        public List<GetBooksDto> Books { get; set; }
        public List<GetCategoryDto> Category { get; set; }
    }
}
