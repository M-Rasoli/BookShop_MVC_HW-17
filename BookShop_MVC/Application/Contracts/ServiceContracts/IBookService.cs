using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;

namespace BookShop_MVC.Application.Contracts.ServiceContracts
{
    public interface IBookService
    {
        List<GetBooksDto> GetBooks();
        void AddNewBook(AddBookDto book);
    }
}
