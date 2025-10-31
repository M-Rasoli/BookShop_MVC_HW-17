using BookShop_MVC.Application.DTOs;

namespace BookShop_MVC.Models
{
    public class AddNewBookModel
    {
        public List<GetCategoryDto> Category { get; set; }
        public AddBookDto Book { get; set; }

    }
}
